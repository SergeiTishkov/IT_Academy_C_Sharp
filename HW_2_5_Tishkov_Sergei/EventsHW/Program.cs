using System;

using EventsLib;

namespace EventsHW
{
    class Program
    {
        static void Main(string[] args)
        {
            NewsOperator novosti = new NewsOperator("Новости");
            NewsOperator izvestia = new NewsOperator("Известия");

            NewsViewer viewer1 = new NewsViewer(NewsType.Новости | NewsType.Происшествия | NewsType.Юмор);
            NewsViewer viewer2 = new NewsViewer(NewsType.Погода | NewsType.Спорт, novosti);

            viewer1.Subscribe(novosti);
            viewer1.Subscribe(izvestia);

            novosti.StartNewDay();
            izvestia.NewsArrived(NewsType.Происшествия, "Срочное сообщение", "Путин поковырялся в носу. Является ли это очередным вызовом Западным партнерам? Читать дальше...");

            Console.WriteLine("Посмотрим ленту новостей чувака, интересующегося новостями, проишествиями и юмором:");
            viewer1.LookMyFeed();

            Console.WriteLine("Посмотрим ленту новостей чувака, подписанного на погоду и спорт");
            viewer2.LookMyFeed();
        }
    }
}
