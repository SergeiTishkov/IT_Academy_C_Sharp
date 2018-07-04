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
    }
}
