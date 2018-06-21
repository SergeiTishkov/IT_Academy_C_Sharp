using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_1_9_Tishkov_Sergei_
{
    public struct Mark : IComparable<Mark>
    {
        public readonly string LectureName;
        public readonly DateTime Date;
        public readonly int MarkNumber;

        public Mark(int markNumber, string lectureName = "noname", DateTime date = new DateTime())
        {
            LectureName = lectureName;
            Date = date;
            if (markNumber > 10 || markNumber < 0)
                MarkNumber = -1;
            else
                MarkNumber = markNumber;
        }

        public int CompareTo(Mark other)
        {
            return MarkNumber.CompareTo(other.MarkNumber);
        }
    }
}
