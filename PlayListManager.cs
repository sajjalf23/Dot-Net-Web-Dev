using System;
using System.Collections.Generic;
public class PlayListManager
{
    public List<Song> AllSongs { get; set; } = new List<Song>();

    public string PlayListName { get; set; }

    public int MaxSongs { set; get; }

    public PlayListManager(List<Song> s, string name, int maxsongs)
    {
        foreach (var song in s)
        {
            AllSongs.Add(song);
        }
        PlayListName = name;
        MaxSongs = maxsongs;
    }

    public void AddMultipleSongs(params Song[] songs)
    {
        foreach (var song in songs)
        {
            if (AllSongs.Count < MaxSongs)
            {
                AllSongs.Add(song);
            }
            else
            {
                Console.WriteLine("Max Songs Limit exceed Cannot add more");
            }
        }
        Console.WriteLine("PlayList added!");
    }

    public PlayListManager(string name, int maxSongs = 10)
    {
        PlayListName = name;
        MaxSongs = maxSongs;
        AllSongs = new List<Song>();
    }
    public void CreatePlaylist(string name, int maxsongs = 10)
    {
        PlayListName = name;
        MaxSongs = maxsongs;
        AllSongs.Clear();
    }

    public List<Song> FindSongsbyGenre(string genre)
    {
        List<Song> samegenre = new List<Song>();
        for (int i = 0; i < AllSongs.Count; i++)
        {
            if (AllSongs[i].Genre.Equals(genre , StringComparison.OrdinalIgnoreCase))
            {
                samegenre.Add(AllSongs[i]);
            }
        }
        return samegenre;
    }

    public void GetPlaylistStatistics()
    {
        int like = 0;
        double duration = 0;
        int songstotal = AllSongs.Count;
        foreach (var song in AllSongs)
        {
            if (song.IsLiked)
                like += 1;
            duration += song.Duration;
        }

        Console.WriteLine($"Total Songs : {songstotal}");
        Console.WriteLine($"Total Duration : {duration} minutes");
        Console.WriteLine($"Total Likes : {like}");
    }


}