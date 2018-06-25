using System;

namespace EventsLib
{
    [Flags]
    public enum NewsType { Новости = 1, Погода = 2, Спорт = 4, Происшествия = 8, Юмор = 16 }
}
