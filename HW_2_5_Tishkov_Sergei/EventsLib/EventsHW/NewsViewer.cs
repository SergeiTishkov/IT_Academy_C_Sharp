using System;
using System.Collections.Generic;

namespace EventsLib
{
    public class NewsViewer
    {
        public NewsType InterestingInformation { get; set; }
        
        private readonly List<(News, NewsOperator)> _feed = new List<(News, NewsOperator)>();

        public NewsViewer(NewsType newsType)
        {
            InterestingInformation = newsType;
        }

        public NewsViewer(NewsType newsType, NewsOperator newsOperator) : this(newsType)
        {
            newsOperator.PopulateFeed += AddNews;
        }

        public void Subscribe(NewsOperator newsOperator)
        {
            newsOperator.PopulateFeed += AddNews;
        }

        public void Unsubscribe(NewsOperator newsOperator)
        {
            newsOperator.PopulateFeed -= AddNews;
        }

        private void AddNews(object sender, NewsEventArgs args)
        {
            if (InterestingInformation.HasFlag(args.Information.Type) && sender is NewsOperator newsOp)
            {
                _feed.Add((args.Information, newsOp));
            }
        }

        public void LookMyFeed()
        {
            Console.WriteLine();
            foreach (var (Information, NewsOp) in _feed)
            {
                Console.WriteLine(Information);
                Console.WriteLine($"Информация была предоставлена новостным оператором {NewsOp.Name}.\n");
            }
        }
    }
}
