using System;
using System.Collections.Generic;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Http;
using NewGame4.Commands.Base;

namespace NewGame4.Commands.SignIn_SignOut
{
    public class SignOutCommand : ExecuteCommand
    {
        private string _userId { get; }

        public SignOutCommand(IFormCollection data, HttpResponse response, HttpRequest request) : base(response, request)
        {
            NameCommand = nameof(UserSignInCommand);
            _userId = data["userId"];
            
            UserParams.Add("Name", string.Empty);
        }

        public override void Execute(ServerContext context)
        {
            var userUnitModel = context.UserModel.Get(_userId);
            userUnitModel.Session = string.Empty;
            userUnitModel.IsAuthorisation = 0;
            UserParams.Add("authorisation", false);
            Send();
        }

    }
}