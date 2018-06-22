using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary
{
    [Serializable]
    public class Track
    {
        public string Name { get; }
        public string Author { get; internal set; }
        public int Number { get; }
        public int Length { get; }
        public Track(string name, int number, int length)
        {
            Name = name;
            Number = number;
            Length = length;
        }

        public override string ToString() => $"Track №{Number}:\n{Name}\nLength : {Length} seconds";
    }
}
