using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EternalQuest
{
    public class GoalManager
    {
        private List<Goal> _goals;
        private int _score;

        public GoalManager()
        {
            _goals = new List<Goal>();
            _score = 0;
        }

        public void Start()
        {
            string userChoice;

            do
            {
                DisplalLevel();
                Console.WriteLine("Menu Options:");
                Console.WriteLine("   1. Create New Goal");
                Console.WriteLine("   2. List Goals");
                Console.WriteLine("   3. Save Goals");
                Console.WriteLine("   4. Load Goals");
                Console.WriteLine("   5. Record Event");
                Console.WriteLine("   6. Quit");
                Console.Write("Select an option: ");
                userChoice = Console.ReadLine();

                if (userChoice == "1")
                {
                    Console.WriteLine("Types of Goals:");
                    Console.WriteLine("   1. Simple Goal");
                    Console.WriteLine("   2. Eternal Goal");
                    Console.WriteLine("   3. Checklist Goal");
                    Console.Write("What type of goal would you like to create? ");
                    string userChoice2 = Console.ReadLine();

                    if (userChoice2 == "1" || userChoice2 == "2" || userChoice2 == "3")
                    {
                        Console.Write("What is the name of the goal? ");
                        string shortName = Console.ReadLine();
                        Console.Write("Give a short description about the goal >");
                        string description = Console.ReadLine();
                        Console.Write("How many points are associated with this goal? ");
                        int points = int.Parse(Console.ReadLine());

                        if (userChoice2 == "1")
                        {
                            CreateGoal("SimpleGoal", shortName, description, points);
                        }
                        else if (userChoice2 == "2")
                        {
                            CreateGoal("EternalGoal", shortName, description, points);
                        }
                        else if (userChoice2 == "3")
                        {
                            CreateGoal("ChecklistGoal", shortName, description, points);
                        }
                    }
                    else
                    {
                        ShowValidAlert();
                    }
                }
                else if (userChoice == "2")
                {
                    ListGoalDetails(_goals);
                }
                else if (userChoice == "3")
                {
                    SaveGoals(_goals);
                }
                else if (userChoice == "4")
                {
                    LoadGoals(_goals);
                }
                else if (userChoice == "5")
                {
                    RecordEvent(_goals);
                }
                else if (userChoice != "6")
                {
                    ShowValidAlert();
                }
            } while (userChoice != "6");
            Console.WriteLine();
        }

        public void CreateGoal(string goalType, string shortName, string description, int points)
        {
            if (goalType == "SimpleGoal")
            {
                SimpleGoal simpleGoal = new SimpleGoal(shortName, description, points);
                _goals.Add(simpleGoal);
            }
            else if (goalType == "EternalGoal")
            {
                EternalGoal eternalGoal = new EternalGoal(shortName, description, points);
                _goals.Add(eternalGoal);
            }
            else if (goalType == "ChecklistGoal")
            {
                Console.Write("How many times does this goal need to be accomplised to receive a bonus? ");
                int goalTarget = int.Parse(Console.ReadLine());
                Console.Write($"What is the bonus for accomplishing the goal {goalTarget} times? ");
                int goalBonus = int.Parse(Console.ReadLine());

                ChecklistGoal checklistGoal = new ChecklistGoal(shortName, description, points, goalTarget, goalBonus);
                _goals.Add(checklistGoal);
            }
            else
            {
                ShowValidAlert();
            }
        }
        
        public void DisplayPlayerInfo()
        {
            ShowSpinner(2);
            Console.WriteLine($"You have {_score} points.");
        }

        public void ListGoalNames(List<Goal> goals)
        {
            ShowSpinner(2);
            for (int i = 0; i < goals.Count(); i++)
            {
                Console.WriteLine($"{i + 1}. {goals[i].GetName()}");
            }
        }

        public void ListGoalDetails(List<Goal> goals)
        {
            ShowSpinner(2);
            for (int i = 0; i < goals.Count(); i++)
            {
                Console.WriteLine($"{i + 1}. {goals[i].GetDetailsString()}");
            }
        }

        public void RecordEvent(List<Goal> goals)
        {
            Console.WriteLine("The goals are:");
            ListGoalNames(goals);
            Console.Write("Which goal did you accomplished? ");
            int goalNumber = int.Parse(Console.ReadLine()) - 1;

            if (goalNumber >= 0 && goalNumber < goals.Count())
            {
                Goal goal = goals[goalNumber];
                if (goal.IsComplete() == false)
                {
                    goals[goalNumber].RecordEvent();
                    _score += goals[goalNumber].GetPoints();
                }
                else
                {
                    Console.WriteLine("This goal has already been achieved.");
                }
            }
            else
            {
                ShowValidAlert();
            }
        }

        public void SaveGoals(List<Goal> goals)
        {
            Console.Write("What is the name of the saved file? ");
            string filename = Console.ReadLine();
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                outputFile.WriteLine(_score);
                foreach (Goal goal in goals)
                {
                    outputFile.WriteLine(goal.GetStringRepresentation());
                }
            }
            ShowSpinner(4);
            Console.WriteLine($"File '{filename}' succesfully saved.");
        }

        public void LoadGoals(List<Goal> goals)
        {
            Console.Write("What is the name of the upload file? ");
            string filename = Console.ReadLine();
            string[] lines = File.ReadAllLines(filename);

            _score = int.Parse(lines[0]) + _score;

            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] parts = line.Split(":");

                string classType = parts[0];
                string[] attributesValues = parts[1].Split("|");
                string shortName = attributesValues[0];
                string description = attributesValues[1];
                int points = int.Parse(attributesValues[2]);

                if (classType == "SimpleGoal")
                {
                    bool isComplete = bool.Parse(attributesValues[3]);
                    SimpleGoal simpleGoal = new SimpleGoal(shortName, description, points, isComplete);
                    goals.Add(simpleGoal);
                }
                else if (classType == "EternalGoal")
                {
                    CreateGoal(classType, shortName, description, points);
                }
                else if (classType == "ChecklistGoal")
                {
                    int target = int.Parse(attributesValues[3]);
                    int bonus = int.Parse(attributesValues[4]);
                    int amountCompleted = int.Parse(attributesValues[5]);
                    ChecklistGoal checklistGoal = new ChecklistGoal(shortName, description, points, target, bonus, amountCompleted);
                    goals.Add(checklistGoal);
                }
            }
            ShowSpinner(4);
            Console.WriteLine($"Fiel '{filename}' succesfuly loaded.");
        }

        public void ShowSpinner(int seconds)
        {
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(seconds);
            List<string> spinnerStrings = new List<string>();
            spinnerStrings.Add("|");
            spinnerStrings.Add("/");
            spinnerStrings.Add("-");
            spinnerStrings.Add("\\");
            int i = 0;
            Console.CursorVisible = false;
            while (DateTime.Now < endTime)
            {
                string spinner = spinnerStrings[i];
                Console.Write(spinner);
                Thread.Sleep(200);
                Console.Write("\b");
                i++;
                if (i >= spinnerStrings.Count)
                {
                    i = 0;
                }
            }
            Console.Write(" \b \b");
            Console.CursorVisible = true;
        }

        public void ShowValidAlert()
        {
            Console.WriteLine();
            Console.WriteLine("Please, select a valid option");
            Console.WriteLine();
        }

    // Player's level method
        public void DisplalLevel()
        {
            string level = "PPP";
            int missingPoints = 00;

            if (_score < 10000)
            {
                level = "Kyu";
                missingPoints = 10000 - _score;
            }
            else if (_score < 20000)
            {
                level = "Kokiri";
                missingPoints = 20000 - _score;
            }
            else if (_score < 30000)
            {
                level = "Hylian";
                missingPoints = 30000 - _score;
            }
            else if (_score < 40000)
            {
                level = "Goron";
                missingPoints = 40000 - _score;
            }
            else if (_score < 50000)
            {
                level = "Zora";
                missingPoints = 50000 - _score;
            }
            else if (_score < 60000)
            {
                level = "Gerudo";
                missingPoints = 60000 - _score;
            }
            else if (_score < 70000)
            {
                level = "Rito";
                missingPoints = 70000 - _score;
            }
            else if (_score < 80000)
            {
                level = "Twili";
                missingPoints = 80000 - _score;
            }
            else if (_score < 90000)
            {
                level = "Sheika";
                missingPoints = 90000 - _score;
            }
            else if (_score < 100000)
            {
                level = "Hero";
                missingPoints = 100000 - _score;
            }
            else if (_score >= 100000)
            {
                level = "Hero of Twilight";
                missingPoints = 0;
            }

            Console.WriteLine();
            DisplayPlayerInfo();
            if (_score < 100000)
            {
                Console.WriteLine($"Level {level} -- {missingPoints} points reamining for the next level");
            }
            else if (_score >= 100000)
            {
                Console.WriteLine($"{level} -- Max Level");
            }
            Console.WriteLine();
        }
    }
}