using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomNameGeneratorLibrary;

namespace Lecture14HW.Helpers
{
    public class Rnd
    {
        private static readonly PersonNameGenerator NameGenerator;
        private static readonly Random Rand;

        static Rnd()
        {
            Rand = new Random(DateTime.Now.Second);
            NameGenerator = new PersonNameGenerator(Rand);
        }

        public static string RandomFirstName => NameGenerator.GenerateRandomFirstName();
        public static string RandomLastName => NameGenerator.GenerateRandomLastName();
        public static double RandomMark => Rand.Next(0, 9) + Rand.NextDouble();
    }
}
