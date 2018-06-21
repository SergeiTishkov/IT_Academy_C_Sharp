using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldHW.Animals
{
    public abstract class Animal : IAnimal // простите, было очень по-дурацки работать с интерфейсом, когда у меня классы были вынесены в отдельную библиотеку
    {                                      // чтобы всю внутрянку делать internal, а все публичное public, в результате получились практически идентичные кролик и тигр
        // TODO Private Set
        public bool IsFull { get; internal set; }
        public bool IsStarved { get; internal set; }
        public bool IsMale { get; }
        public bool IsDead { get; internal set; }
        internal int Id { get; set; }

        private static bool _makeMale = false;

        // TODO Protected. Объяснение ранее.
        internal Animal()
        {
            IsMale = _makeMale;
            // TODO вы в рамках экземплярного конструктора устанавливаете
            // значение. Я более чем уверен что никто кроме вас такого не ожидает
            // CodeSmells / CleanCode - Assigning a value to a static field
            // in a constructor could cause unreliable behavior at runtime
            // since it will change the value for all instances of the class.
            _makeMale = !_makeMale;
        }

        public void Eat()
        {
            IsFull = true;
            IsStarved = false;
        }
    }
}
