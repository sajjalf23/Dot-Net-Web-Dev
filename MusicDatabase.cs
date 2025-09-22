using System;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;


public class MusicDatabase
{
    private string connectionString;
    private SqlConnection connection;


    public MusicDatabase(string dbName = "MusicDB")
    {
        connectionString = $"Server=localhost\\SQLEXPRESS;Database={dbName};Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;"; 

        connection = new SqlConnection(connectionString);
    }

    public void OpenConnection()
    {
        if (connection.State == ConnectionState.Closed)
        {
            connection.Open();

            Console.WriteLine("DB CONNECTED OPEN!");
        }
    }

    public void CloseConnection()
    {
        if (connection.State == ConnectionState.Open)
        {
            connection.Close();

            Console.WriteLine("DB CONNECTION CLOSED!");
        }
    }

    public void CreateTable()
    {
        string query = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Songs' and xtype='U') CREATE TABLE Songs (SongId INT PRIMARY KEY IDENTITY(1, 1),Title NVARCHAR(200),Artist NVARCHAR(100),Duration DECIMAL(4,2),Genre NVARCHAR(50),IsLiked BIT,PlayCount INT DEFAULT 0);";

        SqlCommand cmd = new SqlCommand(query, connection);

        cmd.ExecuteNonQuery();      
    }

    public void InsertSong(Song song)
    {
        string query = @"Insert INTO Songs (Title, Artist, Duration, Genre, IsLiked, PlayCount) Values(@Title , @Artist ,@Duration, @Genre, @IsLiked, @PlayCount);";

        SqlCommand cmd = new SqlCommand(query, connection);

        cmd.Parameters.AddWithValue("@Title", song.Title);

        cmd.Parameters.AddWithValue("@Artist", song.Artist);

        cmd.Parameters.AddWithValue("@Duration", song.Duration);

        cmd.Parameters.AddWithValue("@Genre", song.Genre);

        cmd.Parameters.AddWithValue("@IsLiked", song.IsLiked);

        cmd.Parameters.AddWithValue("@PlayCount", song.PlayCount);


        cmd.ExecuteNonQuery();
    }


    public List<Song> GetAllSongs()
    {
        List<Song> songs = new List<Song>();

        string query = "SELECT * FROM Songs";
        SqlCommand cmd = new SqlCommand(query, connection);

        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Song song = new Song(
                reader.GetInt32(reader.GetOrdinal("SongId")),

                reader.GetString(reader.GetOrdinal("Title")),

                reader.GetString(reader.GetOrdinal("Artist")),

                Convert.ToDouble(reader.GetDecimal(reader.GetOrdinal("Duration"))),

                reader.GetString(reader.GetOrdinal("Genre")),

                reader.GetBoolean(reader.GetOrdinal("IsLiked")),

                reader.GetInt32(reader.GetOrdinal("PlayCount"))

            );
            songs.Add(song);
        }
        return songs;
    }

    public int GetSongCount()
    {
        string query = "SELECT COUNT(*) FROM Songs";

        SqlCommand cmd = new SqlCommand(query, connection);

        return (int)cmd.ExecuteScalar();

    }

    public Song GetSongById(int id)
    {
        string query = "SELECT * FROM Songs WHERE SongId=@Id";
        SqlCommand cmd = new SqlCommand(query, connection);


        cmd.Parameters.AddWithValue("@Id", id);
        SqlDataReader reader = cmd.ExecuteReader();


        if (reader.Read())
        {
            return new Song(

                reader.GetInt32(reader.GetOrdinal("SongId")),

                reader.GetString(reader.GetOrdinal("Title")),

                reader.GetString(reader.GetOrdinal("Artist")),

                Convert.ToDouble(reader.GetDecimal(reader.GetOrdinal("Duration"))),

                reader.GetString(reader.GetOrdinal("Genre")),

                reader.GetBoolean(reader.GetOrdinal("IsLiked")),

                reader.GetInt32(reader.GetOrdinal("PlayCount"))

            );
        }
        return null;
    }
}