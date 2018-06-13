using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldHW.Animals
{
    interface IAnimal
    {
        bool IsFull { get; }
        bool IsStarved { get; }
        bool IsDead { get; }
        bool IsMale { get; }
        void Eat();
    }
}
