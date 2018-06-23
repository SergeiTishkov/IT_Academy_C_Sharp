using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary
{
    [Serializable]
    public class Album
    {
        private readonly Track[] _tracks; 
        public string Name { get; }
        public string Author { get; }
        public int Year { get; }

        public Album(string name, string author, int year, Track[] tracks)
        {
            Name = name;
            Author = author;
            Year = year;
            _tracks = tracks;

            foreach (var track in _tracks)
                track.Author = Author;
        }

        public Track[] GetAllTracks()
        {
            Track[] result = new Track[_tracks.Length];
            _tracks.CopyTo(result, 0);
            return result;
        }

        public Track this[int index]
        {
            get => _tracks[index];
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder($"Album \"{Name}\"\nAuthor : \"{Author}\"\n\nTracks:\n\n");
            foreach (var track in _tracks)
            {
                result.Append(track.ToString());
                result.Append("\n\n");
            }
                

            return result.ToString();
        }
    }
}
