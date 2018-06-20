using System;

using VariantTwo.Event_Args;

namespace VariantTwo.Loggers
{
    public class ConsoleStudentGroupLogger : ILogger
    {
        public void LogStudentAddition(object sender, CollectionChangeResult result)
            =>
            Console.WriteLine($"New student {result.FullName} was added to {(sender as StudentGroup).NumberOfGroup} group.\n");

        public void LogStudentException(object sender, InvalidStudentEventArgs args)
            =>
            Console.WriteLine($"EXPECTION:\n\nMessage: {args.StudentException.Message}\n");

        public ConsoleStudentGroupLogger(StudentGroup group)
        {
            group.SubscribeLogger(this);
        }
    }
}
