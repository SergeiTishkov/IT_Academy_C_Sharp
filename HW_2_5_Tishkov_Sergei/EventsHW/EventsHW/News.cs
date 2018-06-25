
namespace EventsHW.EventsHW
{
    public class News
    {
        public NewsType Type { get; }
        public string Header { get; }
        public string Message { get; }
        private NewsOperator _operator;

        public News(NewsType newsType, string header, string message)
        {
            Type = newsType;
            Header = header;
            Message = message;
        }

        // TODO На будущее - пишите комментарии сверху =)) Сбоку их не удобно читать.
        // вся эта странная возня с оператором имеет вот какую цель -
        // я хотел инкапсулировать оператора так, чтобы не получилось,
        // что можно создать новость, установить ей оператора через публичное свойство,
        // но подписанным на этого оператора людям
        // не пришло сообщение
        public void SetOperator(NewsOperator newsOperator)
        {
            // TODO вы неплохо пишете код, но вам стоит больше уделить внимания
            // принципам и дизайну. У вас скорее будет связь один многое
            // (у одного оператора будет издано много новостей)
            // Да есть подходы, когда вы храните информацию о классе выше,
            // но это не допускает подхода когда вы его вызываете и говорите,
            // что ему сделать. 
            if (newsOperator == null) return;
            _operator = newsOperator;
            newsOperator.NewsArrived(new NewsEventArgs(this));
        }

        // вспомогательный метод для того, чтобы нельзя было сделать новость
        // с неnullовым новостным оператором, не пришедшую подписчикам
        public bool OperatorWasSet() => _operator != null;  

        public override string ToString() => $"{Header}:\n{Message}.\nТип новости: {Type}.\nИнформация предоставлена новостным агенством \"{_operator.Name}\"\n";
    }
}
