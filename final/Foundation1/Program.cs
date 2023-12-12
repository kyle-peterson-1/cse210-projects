//Program 1: Abstraction with YouTube Videos

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Video video1 = new Video("Title1", "Author1", 120);
        video1.AddComment(new Comment("Viewer1", "Great video!"));
        video1.AddComment(new Comment("Viewer2", "Interesting content."));
        video1.AddComment(new Comment("Viewer3", "Well explained."));

        Video video2 = new Video("Title2", "Author2", 180);
        video2.AddComment(new Comment("Viewer4", "Nice video!"));
        video2.AddComment(new Comment("Viewer5", "I learned a lot."));

        Video video3 = new Video("Title3", "Author3", 150);
        video3.AddComment(new Comment("Viewer6", "Awesome presentation."));
        video3.AddComment(new Comment("Viewer7", "Could be more detailed."));

        List<Video> videos = new List<Video> { video1, video2, video3 };

        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");
            foreach (var comment in video.Comments)
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.CommentText}");
            }
            Console.WriteLine();
        }
    }
}

class Video
{
    public string Title { get; }
    public string Author { get; }
    public int Length { get; }
    public List<Comment> Comments { get; }

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return Comments.Count;
    }
}

class Comment
{
    public string CommenterName { get; }
    public string CommentText { get; }

    public Comment(string commenterName, string commentText)
    {
        CommenterName = commenterName;
        CommentText = commentText;
    }
}
