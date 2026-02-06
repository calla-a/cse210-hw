using System;
using System.Transactions;
using YouTubeVideos;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("How to get the Hylian Shield in The Legend of Zelda: Breath of the Wild", "KitosM", 703);
        video1.AddComment("fifakingzzz", "bro i legit died 15 times before watching this... i hate those guardians");
        video1.AddComment("kingjonny", "imagine NOT having the hylian shield in 2026 lmaooo couldn't be me");
        video1.AddComment("yourfriendemanuelle", "yo does this work on master mode?? asking for a friend");
        video1.AddComment("sammii", "i accidentally sold mine...");
        videos.Add(video1);

        Video video2 = new Video("Learn to code in C#", "dante.cs", 316);
        video2.AddComment("junior17", "my teacher is yapping for 2 hours while this video explained it in like 5 mins lol");
        video2.AddComment("kingjonny", "c# is just spicy java change my mind");
        video2.AddComment("xbetitox", "i copied the code and it gave me 47 errors. i think my laptop is haunted or im just stupid");
        video2.AddComment("soli", "coding is 10% typing and 90% staring at a screen wanting to throw the pc out the window");
        videos.Add(video2);

        Video video3 = new Video("How to download more RAM for your PC", "frikiTON", 233);
        video3.AddComment("sp3nc3r", "GUYS DONT DO IT my pc started smoking and now it smells like burnt nuggets");
        video3.AddComment("kingjonny", "i downloaded 500GB of RAM and now i can play roblox in 8K resolution lets goooo");
        video3.AddComment("nefta1314", "me downloading ram at 3am like a boss... wait why is there a fbi van outside my house??");
        video3.AddComment("vichote", "imagine thinking u can actually download ram lol yall are NPCs");
        videos.Add(video3);

        Video video4 = new Video("How to hack my ex's Instagram account", "charlitoss", 522);
        video4.AddComment("jackerman", "bro really made a tutorial for this 💀 we are all going to jail fr fr");
        video4.AddComment("kingjonny", "me: trying to be a hacker / also me: forgets my own wifi password every single day");
        video4.AddComment("sofff", "bestie just move on... this aint it chief 🚩🚩🚩");
        video4.AddComment("revil90", "i tried this and accidentally hacked my own grandma's facebook now she thinks im a cyber-terrorist");
        videos.Add(video4);

        foreach (Video video in videos)
        {
            video.DisplayVideo();
            Console.WriteLine($"{video.NumberOfComments()} comments:");
            foreach (Comment comment in video._comments)
            {
                Console.WriteLine(comment.GetComment());
                Console.WriteLine();
            }
            Console.WriteLine("-------------------------------------------------------------------------");
        }
    }
}