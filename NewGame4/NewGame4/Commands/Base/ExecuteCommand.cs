using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace NewGame4.Commands.Base
{
    public abstract class ExecuteCommand : IExecuteCommand
    {
        public readonly HttpRequest Request;
        public string NameCommand { get; set; }
        protected Dictionary<string, object> UserParams = new Dictionary<string, object>();
        protected HttpResponse Response { get; }
        
        protected ExecuteCommand(HttpResponse response, HttpRequest request)
        {
            Request = request;
            Response = response;
            UserParams.Add("error", false);
            UserParams.Add("error_text", string.Empty);
            Dictionary<string, StringValue> headers = new Dictionary<string, StringValue>();
            Response.OnStarting(() =>
            {
                Response.Headers.Add("Access-Control-Allow-Credentials", "true");
                Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Access-Control-Allow-Headers, Authorization, X-Requested-With, Accept");
                Response.Headers.Add("Access-Control-Allow-Methods", "GET,POST,PUT,DELETE,OPTIONS");
                Response.Headers.Add("Access-Control-Allow-Origin", "localhost:65477");
                Response.Headers.Add("X-Requested-With", "XMLHttpRequest");
                Response.Headers.Add("Host", "localhost:8080");
                return Task.FromResult(0);
            });
            
            Response.StatusCode = 200;
        }
        
        protected async void Send()
        {
            var sendObject = JsonConvert.SerializeObject(UserParams);
            await Response.WriteAsync(sendObject);
            await Response.CompleteAsync();
        }
        
        public abstract void Execute(ServerContext context);
    }
}