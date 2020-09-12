using System;
using Microsoft.AspNetCore.Http;
using NewGame4.Commands.Base;
using NewGame4.Sessions;

namespace NewGame4.Commands.GameProcess
{
    public class CreateNewGameCommand : ExecuteCommand
    {
        private string _countOfPlayers { get; }
        public string _userIdOwner { get; }
        public CreateNewGameCommand(IFormCollection data, HttpResponse response, HttpRequest request) : base(response, request)
        {
            NameCommand = nameof(CreateNewGameCommand);
            _countOfPlayers = data["countOfPlayers"];
            _userIdOwner = data["userId"];

        }      
        public override void Execute(ServerContext context)
        {
            var keys = new string[Convert.ToInt32(_countOfPlayers)];
            
            for (int i = 0; i < Convert.ToInt32(_countOfPlayers); i++)
            {
                var random = new  Random().Next(0, 10000000);
                keys[i] = random.ToString();
                Console.WriteLine(random);
            }
            
            var id = new Random().Next(0, 10000000);
            var session = new SessionUnitModel()
            {
                Id = id.ToString(), 
                UserIdOwner = _userIdOwner,
                Keys = keys,
            };
            
            UserParams.Add("sessionId", id.ToString());
            context.SessionModel.Add(session);
            Send();
        }
    }
}