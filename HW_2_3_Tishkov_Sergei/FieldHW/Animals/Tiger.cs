using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldHW.Animals
{
    class Tiger : Animal
    {
        private static int _id = 1;
        internal Tiger()
        {
            Id = _id++;
        }
    }
}
