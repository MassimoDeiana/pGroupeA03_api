namespace Application.UseCases.Utils
{
    public interface IUpdating<in TI>
    {
        bool Execute(int id, TI dto);
    }
}