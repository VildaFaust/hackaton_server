using System;
using Microsoft.AspNetCore.Http;
using NewGame4.Commands.Base;

namespace NewGame4.Commands
{
    public class UserConnectionCommand : ExecuteCommand
    {
        private string _id { get; }
        private string _session { get; }
        public UserConnectionCommand(IFormCollection data, HttpResponse response, HttpRequest request) : base(response, request)
        {
            NameCommand = nameof(UserConnectionCommand);
            _id = data["userId"];
            _session = data["session"];
        }

        public override void Execute(ServerContext context)
        {
            if (context.UserModel.Contains(_id))
            {
                var user = context.UserModel.Get(_id);
                if (user.Session == _session)
                {
                    Console.WriteLine("authorisation");
                    UserParams.Add("authorisation", true);            
                }
            }
            else
            {
                UserParams["authorisation"] = false;
            }
            Send();
        }
    }
}