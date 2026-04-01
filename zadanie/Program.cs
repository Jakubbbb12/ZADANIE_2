using System;
using System.Collections.Generic;
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
//dodac czas lacznego czasu ze wszystkich trackow
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
        PlaylistTitle = playlistTitle;
        Tracks = new List<Track>();
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

}


class Program
{
    static void Main()
    {
        
    }
}
