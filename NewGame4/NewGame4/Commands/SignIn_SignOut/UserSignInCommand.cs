using System;
using Microsoft.AspNetCore.Http;
using MySql.Data.MySqlClient;
using NewGame4.Commands.Base;
using NewGame4.Users;

namespace NewGame4.Commands.SignIn_SignOut
{
    public class UserSignInCommand : ExecuteCommand
    {
        private string _id { get; }
        private string _email { get; }
        private string _password { get; }

        public UserSignInCommand(IFormCollection data, HttpResponse response, HttpRequest request) : base(response, request)
        {
            NameCommand = nameof(UserSignInCommand);
            _email = data["email"];
            _password = data["password"];
            
            UserParams.Add("Email", string.Empty);
            UserParams.Add("Password", string.Empty);
        }

        public override void Execute(ServerContext context)
        {
            if (!context.UserModel.emails.ContainsKey(_email))
            {
                UserParams["error"] = true;
                UserParams["error_text"] = "Wrong email";
            }
            else
            {
                var userId = context.UserModel.emails[_email];
                var user = context.UserModel.Get(userId);
                
                if (_password == user.Password)
                {
                    var userParam = new Random().Next(0, 100000).ToString();
                    UserParams["userId"] = user.UserId;
                    UserParams["session"] = userParam;
                    user.Session = userParam;
                }
                else
                {
                    UserParams["error"] = true;
                    UserParams["error_text"] = "Wrong password";
                }
            }
            Send();
        }
    }
}
