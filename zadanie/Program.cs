using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Numerics;
//System playlist muzycznych – klasy Track, Playlist, User; tworzenie, modyfikacja i odtwarzanie list utworów
class Track
{
    public String Title{ get; init;}
    public String Singer{ get; init;}
    public int Duration{ get; init;}
    public String Genre{ get; init;}
    public DateTime AddedAt{ get; init;}

    public Track(string title, string singer, int duration, string genre, DateTime addedAt)
    {
        Title = title;
        Singer = singer;
        Duration = duration;
        Genre = genre;
        AddedAt = addedAt;
    }

    public void TrackInfo()
    {
        Console.WriteLine($"Tytuł: {Title}, Wykonawca: {Singer}");
    }
}

class Playlist
{
    public List<Track> Tracks{get; set;}
    public int GetTrackCount()
    {
        return Tracks.Count;
    }

    public int GetTotalDuration()
    {
        int total = 0;

        foreach (Track track in Tracks)
        {
            total = total + track.Duration;
        }

        return total;
    }

    public String PlaylistTitle{ get; set;}

    public Playlist(string playlistTitle)
    {
        if (playlistTitle.Length > 16)
        {
            throw new ArgumentException("Tytuł playlisty nie moe przekraczać 16 znaków");
        }
        
        PlaylistTitle = playlistTitle;
        Tracks = new List<Track>();
        Playlists = new List<Playlist>();
    }
    

    public void PlaylistInfo()
    {
        Console.WriteLine($"Playlista {PlaylistTitle}, Ilość utworów: {GetTrackCount()}");
        Console.WriteLine($"Całkowity czas playlisty: {GetTotalDuration()}");

        foreach (Track track in Tracks)
        {
            track.TrackInfo();
        }

    }

    public void AddTrack(Track track)
    {
        Tracks.Add(track);
    }

    public void RemoveTrack(string title)
    {
        Track toRemove = Tracks.Find(t => t.Title == title);
        Tracks.Remove(toRemove);
    }
    public List<Playlist> Playlists{get; set;}
    public void NewPlaylist(Playlist playlist)
    {
        Playlists.Add(playlist);
    }

    public void RemovePlaylist(string title)
    {
        Playlist toRemove = Playlists.Find(p => p.PlaylistTitle == title);
        Playlists.Remove(toRemove);
    }

    public void Play()
    {
        Console.WriteLine($"Odtwarzanie playlisty: {PlaylistTitle}");
        foreach (Track track in Tracks)
        {
            track.TrackInfo();
        }
    }

    public void PlayRandom()
    {
        Random rng = new Random();
        List<Track> shuffled = new List<Track>(Tracks);

        for (int i = shuffled.Count - 1; i > 0; i--)
        {
            int j = rng.Next(i + 1);
            Track temp = shuffled[i];
            shuffled[i] = shuffled[j];
            shuffled[j] = temp;
        }

        Console.WriteLine($"Odtwarzanie losowe: {PlaylistTitle}");
        foreach (Track track in shuffled)
        {
            track.TrackInfo();
        }
    }

}

class User
{

}



class Program
{
    static void Main()
    {
        
    }
}
