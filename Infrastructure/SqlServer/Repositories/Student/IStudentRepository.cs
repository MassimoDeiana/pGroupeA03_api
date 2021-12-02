namespace Infrastructure.SqlServer.Repositories.Student
{
    public interface IStudentRepository
    {
        bool Update(int id, int idClass);
    }
}