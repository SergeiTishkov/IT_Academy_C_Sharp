using System;

namespace EventsLib
{
    internal class NewsEventArgs : EventArgs
    {
        internal News Information { get; set; }

        internal NewsEventArgs(News information) => Information = information;
    }
}
