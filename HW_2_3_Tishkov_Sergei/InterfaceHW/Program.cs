using System;
using System.Collections.Generic;

using AnimalsLib.Field;

namespace InterfaceHW
{
    class Program
    {
        static void Main(string[] args)
        {
            FieldTest();
        }

        static void FieldTest()
        {
            Field field = Field.NewField(10, 20, 2, 4, 100, 30);

            while (true)
            {
                field.LiveOneDay();
                Console.WriteLine(field.AnimalsStatus());
                Console.ReadKey(true);
                Console.Clear();
            }
        }

        static void RandomTest()
        {
            Random rnd = new Random((int)DateTime.Now.Ticks);
            Dictionary<bool, int> dict = new Dictionary<bool, int>
            {
                { true, 0 },
                { false, 0 }
            };
            for (int i = 0; i < 1000000; i++)
            {
                //Console.WriteLine(rnd.NextDouble() > 0.5);
                dict[rnd.NextDouble() > 0.5]++;
            }
            foreach (var kpv in dict)
            {
                Console.WriteLine($"{kpv.Key} {kpv.Value}");
            }
        }
    }
}
