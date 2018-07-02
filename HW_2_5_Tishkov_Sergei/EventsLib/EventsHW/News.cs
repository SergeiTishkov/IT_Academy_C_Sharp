
namespace EventsLib
{
    internal class News 
    {
        internal NewsType Type { get; }
        internal string Header { get; }
        internal string Message { get; }

        internal News(NewsType newsType, string header, string message)
        {
            Type = newsType;
            Header = header;
            Message = message;
        }

        public override string ToString() => $"{Header}:\n{Message}.\nТип новости: {Type}.";
    }
}
