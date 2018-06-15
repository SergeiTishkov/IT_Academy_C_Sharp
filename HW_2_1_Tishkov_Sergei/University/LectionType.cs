using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education
{
    // TODO (сделано) стоило использовать флаги
    [Flags]
    public enum LectionType
    {
        Math = 1,
        Physics = 2,
        Literature = 4,
        History = 8
    }
}
