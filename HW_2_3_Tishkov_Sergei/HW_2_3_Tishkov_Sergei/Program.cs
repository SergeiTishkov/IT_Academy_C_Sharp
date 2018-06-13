using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FieldHW;
using FieldHW.Animals;
using FieldHW.Field;

namespace HW_2_3_Tishkov_Sergei
{
    class Program
    {
        static void Main(string[] args)
        {
            Field field = Field.GetNewField();
            while (true)
            {
                Console.WriteLine(field.LiveAnotherSeason());
                Console.ReadKey(true);
            }
        }
    }
}
