namespace Healthware.Core.Utility
{
    public interface IParser<TypeToProduce>
    {
        TypeToProduce Parse();
    }
}