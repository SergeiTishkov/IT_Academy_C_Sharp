using System;

namespace EventsHW.EventsHW
{
    public class NewsEventArgs : EventArgs
    {
        public News Information { get; set; }

        public NewsEventArgs(News information) => Information = information;
    }
}
