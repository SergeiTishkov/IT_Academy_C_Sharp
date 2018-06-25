using System;

namespace EventsLib
{
    public class NewsOperator
    {
        public string Name { get; }

        public NewsOperator(string name) => Name = name;

        public void StartNewDay()
        {
            NewsArrived(NewsType.Новости, "Местные новости", "Сегодня президент страны Александр Лукашенко посетил агрогородок \"Бульбино\". Подробнее...");
            NewsArrived(NewsType.Погода, "Погода сегодня", "Сегодня в стране облачно, без осадков. Посмотреть погоду в городе Минск...");
            NewsArrived(NewsType.Спорт, "Новости спорта", "Тем временем в России продолжается Мундиаль, с места событий репортаж Валерия Гусева. Смотреть дальше...");
            NewsArrived(NewsType.Происшествия, "Проишествия", "В Швеции в городе Мальмё в результате стрельбы было ранено 5 человек.\n" + 
                "Полиция считает, что угрозы правопорядку нет. Читать дальше...");
            NewsArrived(NewsType.Юмор, "Анекдот", "Пошли как-то раз Пупа и Лупа в бухгалтерию получать зарплату, но там все перепутали. Читать дальше...");
        }

        internal event EventHandler<NewsEventArgs> PopulateFeed;

        public void NewsArrived(NewsType type, string header, string message)
        {
            if (!string.IsNullOrEmpty(header) && !string.IsNullOrEmpty(message))
            {
                PopulateFeed?.Invoke(this, new NewsEventArgs(new News(type, header, message)));
            }
        }
    }
}
