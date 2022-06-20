namespace Healthware.Core.Utility
{
    public interface IMapper<TIn, Tout>
    {
        Tout MapFrom(TIn item);
    }
}