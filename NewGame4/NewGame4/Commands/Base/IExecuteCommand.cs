namespace NewGame4.Commands.Base
{
    public interface IExecuteCommand : ICommand
    {
        void Execute(ServerContext context);
        
    }
}