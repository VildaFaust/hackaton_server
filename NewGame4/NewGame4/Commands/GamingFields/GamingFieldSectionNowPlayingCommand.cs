using System.Collections.Generic;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Http;
using NewGame4.Commands.Base;
using NewGame4.Commands.SignIn_SignOut;

namespace NewGame4.Commands.GamingFields
{
    public class GamingFieldSectionNowPlayingCommand : ExecuteCommand
    {
        private string _name { get; }
        
        public GamingFieldSectionNowPlayingCommand(IFormCollection data, HttpResponse response, HttpRequest request) : base(response, request)
        {
            NameCommand = nameof(UserSignInCommand);
            _name = data["name"];
            
            UserParams.Add("Name", string.Empty);
        }      
        public override void Execute(ServerContext context)
        {
            Send();
        }
    }
}