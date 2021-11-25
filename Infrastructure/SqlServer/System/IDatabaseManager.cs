namespace Infrastructure.SqlServer.System
{
    public interface IDatabaseManager
    {
        void CreateDatabaseAndTables();

        void FillTables();
    }
}