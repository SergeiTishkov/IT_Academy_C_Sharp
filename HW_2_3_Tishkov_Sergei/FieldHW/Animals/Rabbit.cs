using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace FieldHW.Animals
{
    class Rabbit : Animal
    {
        private static int _id = 1;
        internal Rabbit()
        {
            Id = _id++;
        }
    }
}
