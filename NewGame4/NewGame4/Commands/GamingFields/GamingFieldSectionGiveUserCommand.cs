using System.Collections.Generic;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Http;
using NewGame4.Commands.Base;
using NewGame4.Commands.SignIn_SignOut;

namespace NewGame4.Commands.GamingFields
{
    public class GamingFieldSectionGiveUserCommand : ExecuteCommand
    {
        private string _name { get; }
        private string _buttons { get; }
        private string _cards { get; }
        private string _resources { get; }

        public GamingFieldSectionGiveUserCommand(IFormCollection data, HttpResponse response, HttpRequest request) : base(response, request)
        {
            NameCommand = nameof(UserSignInCommand);
            _name = data["name"];
            _buttons = data["buttons"];
            _cards = data["cards"];
            _resources = data["resources"];
            
            
            UserParams.Add("Name", string.Empty);
            UserParams.Add("Buttons", string.Empty);
            UserParams.Add("Cards", string.Empty);
            UserParams.Add("Resources", string.Empty);
        }      
        public override void Execute(ServerContext context)
        {
            Send();
        }
    }
}