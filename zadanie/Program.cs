using System;
using System.Collections.Generic;

//System playlist muzycznych – klasy Track, Playlist, User; 
//tworzenie, modyfikacja i odtwarzanie list utworów
//WERSJA C#
class Track
{
    public String Title{ get; init;}
    public String Singer{ get; init;}
    public int Duration{ get; init;}
    public String Genre{ get; init;}
    public DateOnly AddedAt{ get; init;}

    public Track(string title, string singer, int duration, string genre, DateOnly addedAt)
    {
        Title = title;
        Singer = singer;
        Duration = duration;
        Genre = genre;
        AddedAt = addedAt;
    }

    public void TrackInfo()
    {
        Console.WriteLine($"Tytuł: {Title}, Wykonawca: {Singer}, {Duration}s, {Genre}, Utworzony {AddedAt}");
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
            throw new ArgumentException("Błąd 03: Tytuł playlisty nie moze przekraczać 16 znaków.");
        }

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

        if (toRemove != null)
        {
            Tracks.Remove(toRemove);
        }
        else
        {
            Console.WriteLine("Błąd 02: Nie znaleziono tracku o podanej nazwie.");
        }
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
    public String Username { get; set; }
    public List<Playlist> Playlists{get; set;}

    public User(string username)
    {
        Username = username;
        Playlists = new List<Playlist>();
    }

    public void NewPlaylist(Playlist playlist)
    {
        Playlists.Add(playlist);
    }

    public void RemovePlaylist(string title)
    {
        Playlist toRemove = Playlists.Find(p => p.PlaylistTitle == title);

        if (toRemove != null)
        {
            Playlists.Remove(toRemove);
        }
        else
        {
            Console.WriteLine("Błąd 01: Nie znaleziono playlisty o podanej nazwie.");
        }
    }

    public void ShowPlaylists()
    {
        foreach (Playlist playlist in Playlists)
        {
            playlist.PlaylistInfo();
        }
    }
}

class Program
{
    static void Main()
    {
        User user1 = new User("Jakub1");
        Playlist playlist1 = new Playlist("Ulubione");
        user1.NewPlaylist(playlist1);
        Playlist playlist2 = new Playlist("Playlista2");
        user1.NewPlaylist(playlist2);

        
        Track track1 = new Track("505", "Arctic Monkeys", 252, "dream pop", new DateOnly(2007, 4, 23));

        Track track2 = new Track("Stolen Dance", "Milky Chance", 314, "Indie pop", new DateOnly(2013, 4, 5));

        playlist1.AddTrack(track1);
        playlist2.AddTrack(track2);

        user1.ShowPlaylists();

        Console.WriteLine("<<Sprawdzanie metod>>");

        user1.RemovePlaylist("Playlista2");
        playlist1.RemoveTrack("505");
        user1.ShowPlaylists();
    }
}
