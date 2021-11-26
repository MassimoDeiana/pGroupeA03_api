namespace Application.UseCases.Utils
{
    public interface IDeleting<in T>
    {
        bool Execute(T dto);
    }
}