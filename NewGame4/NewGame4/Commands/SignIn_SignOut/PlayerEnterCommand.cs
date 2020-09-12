using Microsoft.AspNetCore.Http;
using NewGame4.Commands.Base;

namespace NewGame4.Commands.SignIn_SignOut
{
    public class PlayerEnterCommand : ExecuteCommand
    {
        private string _key { get; }
        
        public PlayerEnterCommand(IFormCollection data, HttpResponse response, HttpRequest request) : base(response, request)
        {
            _key = data["key"];
            NameCommand = nameof(PlayerEnterCommand);
        }

        public override void Execute(ServerContext context)
        {
            if (context.SessionModel.sessions.ContainsKey(_key))
            {
                UserParams.Add("authorisation", true);
                UserParams.Add("sessionId", context.SessionModel.Get(context.SessionModel.sessions[_key]).Id);
            }
            Send();
        }
    }
}