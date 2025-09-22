using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Song> songs = new List<Song>();
        PlayListManager playlistManager = new PlayListManager("Myplylist", 10);
        FileOperation fileManager = new FileOperation();
        MusicDatabase db = new MusicDatabase("MusicDB");

        bool running = true;

        while (running)
        {
            Console.WriteLine("");

            Console.WriteLine(" Music Management Menu  ");

            Console.WriteLine("1 Create Songs  ");

            Console.WriteLine("2 Display Songs ");

            Console.WriteLine("3 Save Songs to txt File ")
            ;
            Console.WriteLine("4 Load Songs from txt File");

            Console.WriteLine("5 Insert Songs , DB ");

            Console.WriteLine("6 Display Songs, DB");

            Console.WriteLine("7 Song by id DB ");

            Console.WriteLine("8 Total Songs (#) DB");

            Console.WriteLine("9 Create Playlist");

            Console.WriteLine("10 Display Playlist Stats");

            Console.WriteLine("11 Find Songs by Genre");

            Console.WriteLine("12 Play a Song ");

            Console.WriteLine("13 Exit");




            Console.Write(" Select : ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":

                    songs.Add(new Song(1, "Pineapple", "ABC", 3, "Pop"));

                    songs.Add(new Song(2, "MAngo", "DEF", 5, "Classic"));

                    songs.Add(new Song(3, "Orange", "GHI", 3, "Pop"));

                    songs.Add(new Song(4, "apple", "JKL", 8, "Pop"));

                    songs.Add(new Song(5, "carrot", "MNOP", 4, "Classic"));

                    break;

                case "2":

                    foreach (var s in songs)
                        s.DisplaySongInfo();
                    break;

                case "3":

                    fileManager.SaveSongsToText(songs, "songs.txt");
                    break;

                case "4":

                    songs = fileManager.LoadSongsFromText("songs.txt");
                    foreach (var s in songs)
                    {
                        s.DisplaySongInfo();
                    }
                    break;

                case "5":

                    db.OpenConnection();
                    db.CreateTable();

                    foreach (var s in songs)
                        db.InsertSong(s);

                    db.CloseConnection();

                    break;

                case "6":

                    db.OpenConnection();
                    var dbSongs = db.GetAllSongs();

                    foreach (var s in dbSongs)
                        s.DisplaySongInfo();

                    db.CloseConnection();

                    break;

                case "7":

                    Console.Write("ID: ");
                    int id = int.Parse(Console.ReadLine());

                    db.OpenConnection();
                    var songg = db.GetSongById(id);

                    if (songg != null)
                        songg.DisplaySongInfo();
                    else
                        Console.WriteLine("not found!");

                    db.CloseConnection();

                    break;

                case "8":

                    db.OpenConnection();

                    int count = db.GetSongCount();
                    Console.WriteLine($" songs (DB): {count}");

                    db.CloseConnection();

                    break;

                case "9":

                    Console.Write("Playlist Name: ");
                    string name = Console.ReadLine();
                    playlistManager.CreatePlaylist(name);

                    playlistManager.AddMultipleSongs(songs.ToArray());

                    break;

                case "10":

                    playlistManager.GetPlaylistStatistics();

                    break;

                case "11":

                    Console.Write("Genre: ");

                    string genre = Console.ReadLine();

                    var same = playlistManager.FindSongsbyGenre(genre);

                    foreach (var s in same)
                        s.DisplaySongInfo();

                    break;

                case "12":

                    Console.Write("Enter ID to play: ");
                    int sid = int.Parse(Console.ReadLine());
                    var song = songs.Find(s => s.SongId == sid);

                    if (song != null)
                    {
                        song.PlaySong();
                        song.DisplaySongInfo();
                    }
                    else Console.WriteLine("not found!");

                    break;

                case "13":

                    running = false;
                    Console.WriteLine("Exiting program...");

                    break;

                default:

                    Console.WriteLine("Notvalid try again.");
                    break;
            }
        }
    }

}
