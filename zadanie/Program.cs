using System;
using System.Reflection;
//System playlist muzycznych – klasy Track, Playlist, User; tworzenie, modyfikacja i odtwarzanie list utworów
class Track
{
    public String Title{ get; set;}
    public String Singer{ get; set;}
    public int Duration{ get; set;}
    public String Genre{ get; set;}
    public DateTime AddedAt{ get; set;}

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









class Program
{
    static void Main()
    {
        
    }
}
