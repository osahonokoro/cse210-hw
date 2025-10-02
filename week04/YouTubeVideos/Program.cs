using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videoList = new List<Video>();

        Video video1 = new Video("How to Bake Bread", "Chef Emma", 480);
        video1.AddComment(new Comment("Alice", "This was super helpful!"));
        video1.AddComment(new Comment("Bob", "I love the step-by-step instructions."));
        video1.AddComment(new Comment("Charlie", "Can you do sourdough next?"));

        Video video2 = new Video("Top 10 Travel Destinations", "Wanderlust TV", 720);
        video2.AddComment(new Comment("Diana", "Adding these to my bucket list!"));
        video2.AddComment(new Comment("Ethan", "Great visuals and editing."));
        video2.AddComment(new Comment("Fiona", "Loved the Bali segment!"));

        Video video3 = new Video("Intro to Python Programming", "CodeAcademy", 900);
        video3.AddComment(new Comment("George", "Perfect for beginners."));
        video3.AddComment(new Comment("Hannah", "Clear and concise."));
        video3.AddComment(new Comment("Ian", "Can you cover classes next?"));

        videoList.Add(video1);
        videoList.Add(video2);
        videoList.Add(video3);

        foreach (Video video in videoList)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLengthInSeconds()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.GetCommenterName()}: {comment.GetText()}");
            }
            Console.WriteLine();
        }
    }
}
