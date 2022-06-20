namespace Healthware.Core.Utility
{
    public interface IFactory<TypeToCreate>
    {
        TypeToCreate Create();
    }
}