using System;

namespace EventsHW.EventsHW
{
    public class NewsOperator
    {
        public string Name { get; }

        public NewsOperator(string name) => Name = name;

        public void StartNewDay()
        {
            new News(NewsType.Новости, "Местные новости", "Сегодня президент страны Александр Лукашенко посетил агрогородок \"Бульбино\". Подробнее...").SetOperator(this);
            new News(NewsType.Погода, "Погода сегодня", "Сегодня в стране облачно, без осадков. Посмотреть погоду в городе Минск...").SetOperator(this);
            new News(NewsType.Спорт, "Новости спорта", "Тем временем в России продолжается Мундиаль, с места событий репортаж Валерия Гусева. Смотреть дальше...").SetOperator(this);
            new News(NewsType.Происшествия, "Проишествия", "В Швеции в городе Мальмё в результате стрельбы было ранено 5 человек.\n" + 
                "Полиция считает, что угрозы правопорядку нет. Читать дальше...").SetOperator(this);
            new News(NewsType.Юмор, "Анекдот", "Пошли как-то раз Пупа и Лупа в бухгалтерию получать зарплату, но там все перепутали. Читать дальше...").SetOperator(this);
        }

        public event EventHandler<NewsEventArgs> PopulateFeed;

        public void NewsArrived(NewsEventArgs args)
        {
            if (args.Information == null) return;
            // Если у новости нету оператора,
            // 1. установить оператора
            // 2. Далее вообще неожиданное поведение
            //    - новость вернётся в оператора и снова вызовет этот метод.
            if (!args.Information.OperatorWasSet()) 
                // сделано для того, чтобы если вызвать этот метод вручную из мейна,
                // не вызвав метод SetOperator на новости, Оператор не был null
                args.Information.SetOperator(this);
            else
                PopulateFeed?.Invoke(this, args);
        }
    }
}
