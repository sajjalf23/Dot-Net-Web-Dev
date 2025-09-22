using System;

public class Song
{
    public int SongId { get; set; }
    public string Title { set; get; }

    public string Artist { set; get; }

    public double Duration { set; get; }

    public string Genre { get; set; }

    public bool IsLiked { get; set; }

    public int PlayCount { set; get; }

    public Song(int id, string title, string artist, double duration, string genre,
    bool isLiked = false, int Playcount = 0)
    {
        SongId = id;
        Title = title;
        Artist = artist;
        Duration = duration;
        Genre = genre;
        IsLiked = isLiked;
        PlayCount = Playcount;
    }

    public void PlaySong()
    {
        PlayCount += 1;
        Console.WriteLine("Song is Playing!");
    }

    public void DisplaySongInfo()
    {
        Console.WriteLine($"ID: {SongId}");
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Artist: {Artist}");
        Console.WriteLine($"Duration: {Duration}");
        Console.WriteLine($"Genre: {Genre}");
        Console.WriteLine($"IsLiked: {IsLiked}");
        Console.WriteLine($"PlayCount: {PlayCount}");
    }
}
