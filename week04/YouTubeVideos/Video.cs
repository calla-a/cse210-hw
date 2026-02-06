using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YouTubeVideos
{
    public class Video
    {
        public string _title;
        public string _author;
        public int _length;
        public List<Comment> _comments = new List<Comment>();

        public Video(string title, string author, int length)
        {
            _title = title;
            _author = author;
            _length = length;
        }

        public void DisplayVideo()
        {
            Console.WriteLine($"{_title} - {_length} sec.");
            Console.WriteLine($"{_author}");
            Console.WriteLine();
        }

        public void AddComment(string person, string text)
        {
            Comment comment = new Comment();
            comment._person = person;
            comment._text = text;
            _comments.Add(comment);
        }

        public int NumberOfComments()
        {
            int total = _comments.Count();
            return total;
        }
    }
}