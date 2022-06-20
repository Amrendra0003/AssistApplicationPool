namespace Healthware.Core.Utility
{
    public interface IParameterizedCommand<Input>
    {
        void Execute(Input item);
    }
}