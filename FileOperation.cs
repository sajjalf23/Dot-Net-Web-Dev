using System;
using System.IO;
using System.Collections.Generic;
public class FileOperation
{
    public void SaveSongsToText(List<Song> songs, string filename)
    {
        StreamWriter sw = new StreamWriter(filename, true);
        foreach (var s in songs)
        {
            string data = $"{s.SongId},{s.Title},{s.Artist},{s.Duration},{s.Genre},{s.IsLiked},{s.PlayCount}";
            sw.WriteLine(data);
        }
        sw.Close();
    }

    public List<Song> LoadSongsFromText(string filename)
    {
        List<Song> songs = new List<Song>();
        if (!File.Exists(filename))
        {
            Console.WriteLine($" File '{filename}' does not exist.");
            return songs;
        }
        StreamReader sr = new StreamReader($"{filename}");
        string data = "";

        while ((data = sr.ReadLine()) != null)
        {
            string[] parts = data.Split(',');
            Song a = new Song(int.Parse(parts[0]), parts[1], parts[2], double.Parse(parts[3]), parts[4], bool.Parse(parts[5])
            , int.Parse(parts[6]));
            songs.Add(a);
        }

        sr.Close();

        return songs;
    }
}