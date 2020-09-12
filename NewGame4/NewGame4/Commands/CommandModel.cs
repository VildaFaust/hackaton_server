using System;
using System.Collections.Generic;
using NewGame4.Commands.Base;

namespace NewGame4.Commands
{
    public class CommandModel
    {
        public event Action<IExecuteCommand> Add;
        
        public void AddCommand(IExecuteCommand command)
        {
            Add?.Invoke(command);
        }
    }
}