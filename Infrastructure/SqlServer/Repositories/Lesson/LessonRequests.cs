namespace Infrastructure.SqlServer.Repositories.Lesson
{
    public partial class LessonRepository
    {
        private const string TableName = "lesson";

        public const string ColId = "idlesson",
            ColSubject = "subject";

        private static readonly string ReqCreate = $@"INSERT INTO {TableName}({ColSubject}) OUTPUT INSERTED.{ColId} 
                    VALUES(@{ColSubject})";

    }
}