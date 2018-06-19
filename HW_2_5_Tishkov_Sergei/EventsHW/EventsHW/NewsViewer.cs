using System;
using System.Collections.Generic;

namespace EventsHW.EventsHW
{
    public class NewsViewer
    {
        public NewsType InterestingInformation { get; set; }
        private List<News> _feed = new List<News>();

        public NewsViewer(NewsType newsType) => InterestingInformation = newsType;

        public NewsViewer(NewsType newsType, NewsOperator newsOperator) : this(newsType) => newsOperator.PopulateFeed += AddNews;

        public void Subscribe(NewsOperator newsOperator) => newsOperator.PopulateFeed += AddNews;

        public void Unsubscribe(NewsOperator newsOperator) => newsOperator.PopulateFeed -= AddNews;

        private void AddNews(object sender, NewsEventArgs args)
        {
            if (InterestingInformation.HasFlag(args.Information.Type))
                _feed.Add(args.Information);
        }

        public void LookMyFeed()
        {
            Console.WriteLine();
            foreach (var news in _feed)
                Console.WriteLine(news);
        }
    }
}
