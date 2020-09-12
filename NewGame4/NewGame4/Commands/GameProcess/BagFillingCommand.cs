using System.Collections.Generic;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Http;
using NewGame4.Commands.Base;
using NewGame4.Commands.SignIn_SignOut;

namespace NewGame4.Commands.GameProcess
{
    public class BagFillingCommand : ExecuteCommand
    {
        private string _name { get; }
        private string _bags { get; }
        private string _buttons { get; }
        private string _cards { get; }
        private string _jokers { get; }
        private string _resources { get; }

        public BagFillingCommand(IFormCollection data, HttpResponse response, HttpRequest request) : base(response, request)
        {
            NameCommand = nameof(BagFillingCommand);
            _name = data["name"];
            _buttons = data["buttons"];
            _cards = data["cards"];
            _resources = data["resources"];
            _jokers = data["jokers"];
            _bags = data["bags"];
            
            UserParams.Add("Name", string.Empty);
            UserParams.Add("Bags", string.Empty);
            UserParams.Add("Buttons", string.Empty);
            UserParams.Add("Cards", string.Empty);
            UserParams.Add("Jokers", string.Empty);
            UserParams.Add("Resources", string.Empty);
        }      
        public override void Execute(ServerContext context)
        {
            Send();
        }

    }
}