using System;

using EventsHW.EventsHW;

namespace EventsHW
{
    class Program
    {
        static void Main(string[] args)
        {
            NewsOperator novosti = new NewsOperator("Новости");

            NewsViewer viewer1 = new NewsViewer(NewsType.Новости | NewsType.Происшествия | NewsType.Юмор);

            viewer1.Subscribe(novosti);

            novosti.StartNewDay();
            novosti.NewsArrived(new NewsEventArgs(new News(NewsType.Происшествия, "Срочное сообщение", "Путин поковырялся в носу. Является ли это очередным вызовом Западным партнерам? Читать дальше...")));

            Console.WriteLine("Посмотрим ленту новостей чувака, интересующегося новостями, проишествиями и юмором:");
            viewer1.LookMyFeed();

            Console.WriteLine("Создадим второго субскрайбера, подпишем его на погоду и спорт");
            NewsViewer viewer2 = new NewsViewer(NewsType.Погода | NewsType.Спорт, novosti);

            novosti.NewsArrived(new NewsEventArgs(new News(NewsType.Погода, "***Погода сегодня***", "Сегодня в стране облачно, без осадков. Посмотреть погоду в городе Минск...")));
            novosti.NewsArrived(new NewsEventArgs(new News(NewsType.Спорт, "***Новости спорта***", "Тем временем в России продолжается Мундиаль, с места событий репортаж Валерия Гусева. Смотреть дальше...")));
            novosti.NewsArrived(new NewsEventArgs(new News(NewsType.Происшествия, "***Срочное сообщение***", "Путин поковырялся в носу. Является ли это очередным вызовом Западным партнерам? Читать дальше...")));

            viewer2.LookMyFeed();
        }
    }
}
