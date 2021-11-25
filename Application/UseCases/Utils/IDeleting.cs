namespace Application.UseCases.Utils
{
    public interface IDeleting<in T>
    {
        bool Execute(string request, T dto, string col);
    }
}