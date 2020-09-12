using System;
using Microsoft.AspNetCore.Http;
using NewGame4.Commands.Base;

namespace NewGame4.Commands.UtilityCommands
{
    public class ScreenChangedCommand : ExecuteCommand
    {
        private string _id { get; }
        private int _screen { get; }
        
        public ScreenChangedCommand(IFormCollection data, HttpResponse response, HttpRequest request) : base(response, request)
        {
            _screen = Convert.ToInt32(data["screen"]);
            _id = data["userId"];
            NameCommand = nameof(ScreenChangedCommand);
        }

        public override void Execute(ServerContext context)
        {
            // var user = context.UserModel.Get(_id);
            // user.CurrentScreen = _screen;
            Send();
        }
    }
}