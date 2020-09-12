using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using NewGame4.Commands.Base;
using Newtonsoft.Json;

namespace NewGame4.Commands.Subscription
{
    public class GetPricingCommand : ExecuteCommand
    {
        public GetPricingCommand(IFormCollection data, HttpResponse response, HttpRequest request) : base(response, request)
        {
            
        }

        public override void Execute(ServerContext context)
        {
            var data = File.ReadAllText("Pricing.json");
            OverrideSend(data);
        }
        
        protected async void OverrideSend(string data)
        {
            Console.WriteLine(NameCommand);
            await Response.WriteAsync(data);
        }
    }
}