using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // VIDEO 1
        Video v1 = new Video("How to Code in C#", "Justin", 600);
        v1.AddComment(new Comment("Alex", "Great tutorial!"));
        v1.AddComment(new Comment("Maria", "Very helpful"));
        v1.AddComment(new Comment("John", "Thanks bro!"));
        videos.Add(v1);

        // VIDEO 2
        Video v2 = new Video("Workout for Beginners", "Coach Mike", 900);
        v2.AddComment(new Comment("Jake", "I feel stronger already"));
        v2.AddComment(new Comment("Anna", "Nice routine!"));
        v2.AddComment(new Comment("Leo", "This works!"));
        videos.Add(v2);

        // VIDEO 3
        Video v3 = new Video("Top 10 Games 2026", "GamerX", 1200);
        v3.AddComment(new Comment("Chris", "Awesome list"));
        v3.AddComment(new Comment("Kim", "I love these games"));
        v3.AddComment(new Comment("Ray", "Add more next time"));
        videos.Add(v3);

        // DISPLAY OUTPUT
        foreach (Video video in videos)
        {
            Console.WriteLine("Title: " + video.Title);
            Console.WriteLine("Author: " + video.Author);
            Console.WriteLine("Length: " + video.Length + " seconds");
            Console.WriteLine("Comments Count: " + video.GetCommentCount());

            Console.WriteLine("Comments:");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.Name}: {comment.Text}");
            }

            Console.WriteLine("---------------------------");
        }
    }
}