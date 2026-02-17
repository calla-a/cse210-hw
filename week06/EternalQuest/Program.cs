using System;
using EternalQuest;

// Added a Function in GoalManager that shows and manages the player's level
// Added logic to avoid adding points if a goal has already been completed
// Added logic to handle errors if the user enters a value that is not available
// in the options
// Created an additional constructor for simple and checklist goal so that it fits
// the data loaded from a file

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        goalManager.Start();
    }
}