using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldHW.Animals
{
    public abstract class Animal : IAnimal // простите, было очень по-дурацки работать с интерфейсом, когда у меня классы были вынесены в отдельную библиотеку
    {                                      // чтобы всю внутрянку делать internal, а все публичное public, в результате получились практически идентичные кролик и тигр
        public bool IsFull { get; private set; }
        public bool IsStarved { get; private set; }
        public bool IsMale { get; }
        public bool IsDead { get; internal set; }
        internal int Id { get; set; }

        private static bool _makeMale = false; 

        protected Animal()
        {
            IsMale = _makeMale;
            _makeMale = !_makeMale;
            /*
             комментарий ученика:
             Эта переменная специально создана для того, чтобы
             половина животных была самками, половина самцами
             по некой невнятной причине мой рандом просто вообще не хотел плодить разных животных,
             если между их созданием не происходил Thread.Sleep(1), что при большом количестве
             производимых животных тормозило программу дальше некуда
             никаких происшествий с моим кодом установка этой переменной внутри конструктора не может сделать
             */
        }

        public void Eat()
        {
            IsFull = true;
            IsStarved = false;
        }
        public void Starve()
        {
            IsFull = false;
            IsStarved = true;
        }
    }
}
