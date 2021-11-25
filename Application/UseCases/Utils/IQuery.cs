namespace Application.UseCases.Utils
{
    public interface IQuery<out TO>
    {
        TO Execute();
    }
}