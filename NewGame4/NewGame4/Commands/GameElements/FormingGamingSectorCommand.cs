using System.Collections.Generic;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Http;
using NewGame4.Commands.Base;
using NewGame4.Commands.SignIn_SignOut;

namespace NewGame4.Commands.GameElements
{
    public class FormingGamingSectorCommand : ExecuteCommand
    {
        private string _name { get; }
        private string _secondName { get; }       
        private string _images { get; }
        private string _bags { get; }
        private string _bagNumber { get; }
        private string _buttons { get; }
        private string _cards { get; }
        private string _selectedCards { get; }
        private string _jokers { get; }
        private string _resources { get; }

        public FormingGamingSectorCommand(IFormCollection data, HttpResponse response, HttpRequest request) : base(response, request)
        {
            NameCommand = nameof(FormingGamingSectorCommand);
            _buttons = data["buttons"];
            _name = data["name"];
            _secondName = data["secondName"];
            _bags = data["bags"];
            _bagNumber = data["bagNumber"];
            _cards = data["cards"];
            _selectedCards = data["selectedCards"];
            _images = data["images"];
            _resources = data["resources"];
            _jokers = data["jokers"];
            
            
            UserParams.Add("Name", string.Empty);
            UserParams.Add("SecondName", string.Empty);
            UserParams.Add("Images", string.Empty);
            UserParams.Add("Bags", string.Empty);
            UserParams.Add("BagNumber", string.Empty);
            UserParams.Add("Buttons", string.Empty);
            UserParams.Add("Cards", string.Empty);
            UserParams.Add("SelectedCards", string.Empty);
            UserParams.Add("Jokers", string.Empty);
            UserParams.Add("Resources", string.Empty);
        }     
        
        public override void Execute(ServerContext context)
        {
            Send();
        }
    }
}