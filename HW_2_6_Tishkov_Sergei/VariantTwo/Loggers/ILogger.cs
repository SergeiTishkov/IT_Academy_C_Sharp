using VariantTwo.Event_Args;

namespace VariantTwo.Loggers
{
    public interface ILogger
    {
        void LogStudentAddition(object sender, CollectionChangeResult result);

        void LogStudentException(object sender, InvalidStudentEventArgs args);
    }
}
