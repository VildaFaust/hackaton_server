using System;
using Microsoft.AspNetCore.Http;
using NewGame4.Commands.Base;
using NewGame4.Users;

namespace NewGame4.Commands.Registration
{
    public class RegistrationCommand : ExecuteCommand
    {
        private string _id { get; }
        private string _name { get; }
        private string _secondName { get; }
        private string _password { get; }
        private string _email { get; }

        public RegistrationCommand(IFormCollection data, HttpResponse response, HttpRequest request) : base(response, request)
        {
            NameCommand = nameof(RegistrationCommand);
            _id = data["id"];
            _name = data["name"];
            _secondName = data["secondName"];
            _password = data["password"];
            _email = data["email"];

            UserParams.Add("userId", string.Empty);
            UserParams.Add("session", string.Empty);
        }

        public override void Execute(ServerContext context)
        {
            if (context.UserModel.emails.ContainsKey(_email))
            {
                UserParams["error"] = true;
                UserParams["error_text"] = "Email exist";
            }
            else
            {
                var userParam = new Random().Next(0, 100000).ToString();
                UserParams["userId"] = userParam;
                UserParams["session"] = userParam;
                var user = new UserUnitModel()
                {
                    Name = _name,
                    SecondName = _secondName,
                    Email = _email,
                    Password = _password,
                    Session = userParam,
                    UserId = userParam,
                    IsAuthorisation = 1,
                    IsNew = true
                };
                context.UserModel.Add(_email, user);
            }
            
            Send();
        }
    }
}