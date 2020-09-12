using System;
using System.Collections.Generic;
using System.Diagnostics;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Http;
using NewGame4.Commands.Base;
using NewGame4.Commands.SignIn_SignOut;

namespace NewGame4.Commands.Subscription
{
    public class LeaderBuySubscriptionCommand : ExecuteCommand
    {
        private string _password { get; }
        private string _email { get; }
        private string _allTariffs { get; }
        private string _currentTariff { get; }
        private string _tariffRemainingTime { get; }
        
        public LeaderBuySubscriptionCommand(IFormCollection data, HttpResponse response, HttpRequest request) : base(response, request)
        {
            NameCommand = nameof(UserSignInCommand);
            _password = data["password"];
            _email = data["email"];
            _allTariffs = data["allTariffs"];
            _currentTariff = data["currentTariff"];
            _tariffRemainingTime = data["tariffRemainingTime"];
            
            UserParams.Add("Password", string.Empty);
            UserParams.Add("Email", string.Empty);
            UserParams.Add("AllTariffs", string.Empty);
            UserParams.Add("CurrentTariff", string.Empty);
            UserParams.Add("TariffRemainingTime", string.Empty);
        }      
        
        public override void Execute(ServerContext context)
        {
            Send();
        }
    }
}