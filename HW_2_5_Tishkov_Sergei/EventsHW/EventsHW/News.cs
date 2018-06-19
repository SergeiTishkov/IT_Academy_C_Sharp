
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

        public void SetOperator(NewsOperator newsOperator)  // вся эта странная возня с оператором имеет вот какую цель - я хотел инкапсюлировать оператора так, чтобы не получилось,
        {                                                   // что можно создать новость, установить ей оператора через публичное свойство, но подписанным на этого оператора людям
            if(newsOperator != null)                        // не пришло сообщение
            {
                _operator = newsOperator;
                newsOperator.NewsArrived(new NewsEventArgs(this));
            }
        }

        public bool OperatorWasSet() => _operator != null;  // вспомогательный метод для того, чтобы нельзя было сделать новость с неnullовым новостным оператором, не пришедшую подписчикам

        public override string ToString() => $"{Header}:\n{Message}.\nТип новости: {Type}.\nИнформация предоставлена новостным агенством \"{_operator.Name}\"\n";
    }
}
