import random
from datetime import date

class Track:
    def __init__(self, title, singer, duration, genre, addedat):
        self.title = title
        self.singer = singer
        self.duration = duration
        self.genre = genre
        self.addedat = addedat
    
    def track_info(self):
        print(f"Tytuł: {self.title}, Wykonawca: {self.singer}, {self.duration}s, {self.genre}, Utworzony {self.addedat}")

class Playlist:
    def __init__(self, playlist_title):
        if len(playlist_title) > 16:
            raise ValueError("Błąd 01: Tytuł nie moze przekraczać 16 znaków.")
        
        self.playlist_title = playlist_title
        self.tracks = [] #lista tracków

    def get_total_duration(self):
        total = 0
        for track in self.tracks:
            total = total + track.duration
        return total

    def playlist_info(self):
        print(f"Playlista {self.playlist_title}, ilość utworów: {len(self.tracks)}")
        print(f"Całkowity czas: {self.get_total_duration()}s")

        for track in self.tracks:
            track.track_info()

    def add_track(self, track):
        self.tracks.append(track)
    
    def remove_track(self, title):
        to_remove = next((t for t in self.tracks if t.title == title), None)
        if to_remove is not None:
            self.tracks.remove(to_remove)
        else:
            print("Błąd 02: Nie znaleziono tracku o podanej nazwie.")
    
    def play(self):
        print(f"Odtwarzanie playlisty {self.playlist_title}")
        for track in self.tracks:
            track.track_info()

    def play_random(self):
        shuffled = list(self.tracks)
        random.shuffle(shuffled)

        print(f"Odtwarzanie losowe playlisty {self.playlist_title}")
        for track in shuffled:
            track.track_info()

class User:
    def __init__(self, username):
        self.username = username
        self.playlists = []
    
    def new_playlist(self, playlist):
        self.playlists.append(playlist)

    def remove_playlist(self, title):
        to_remove = next((p for p in self.playlists if p.playlist_title == title), None)
        if to_remove is not None:
            self.playlists.remove(to_remove)
        else:
            print("Błąd 03: Nie znaleziono playlisty o podanej nazwie.")

    def show_playlists(self):
        for playlist in self.playlists:
            playlist.playlist_info()

user1 = User("Jakub1")
playlist1 = Playlist("Ulubione")
user1.new_playlist(playlist1)
playlist2 = Playlist("Playlista2")
user1.new_playlist(playlist2)

track1 = Track("505", "Arctic Monkeys", 252, "dream pop", date(2007, 4, 23))
track2 = Track("Stolen Dance", "Milky Chance", 314, "indie pop", date(2013, 4, 5))

playlist1.add_track(track1)
playlist2.add_track(track2)

user1.show_playlists()

print("<<Sprawdzanie metod>>")

user1.remove_playlist("Playlista2")
playlist1.remove_track("505")
user1.show_playlists()