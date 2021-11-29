namespace Infrastructure.SqlServer.Repositories.Note
{
    public partial class NoteRepository
    {
        private const string TableName = "note";

        public const string ColId = "idnote",
            ColIdTeacher = "idteacher",
            ColIdStudent = "idstudent",
            ColDateNote = "datenote",
            ColMessage = "message";

        private static readonly string ReqCreate = $@"
            INSERT INTO {TableName}({ColIdTeacher}, {ColIdStudent}, {ColDateNote}, {ColMessage})
            OUTPUT INSERTED.{ColId}
            VALUES(@{ColIdTeacher}, @{ColIdStudent}, @{ColDateNote}, @{ColMessage})";
    }
}