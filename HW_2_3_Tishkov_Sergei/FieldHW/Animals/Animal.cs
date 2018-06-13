using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldHW.Animals
{
    public abstract class Animal : IAnimal // простите, было очень по-дурацки работать с интерфейсом, когда у меня классы были вынесены в отдельную библиотеку
    {                                      // чтобы всю внутрянку делать internal, а все публичное public, в результате получились практически идентичные кролик и тигр
        public bool IsFull { get; internal set; }
        public bool IsStarved { get; internal set; }
        public bool IsMale { get; }
        public bool IsDead { get; internal set; }
        internal int Id { get; set; }

        private static bool _makeMale = false;

        internal Animal()
        {
            IsMale = _makeMale;
            _makeMale = !_makeMale;
        }

        public void Eat()
        {
            IsFull = true;
            IsStarved = false;
        }
    }
}
