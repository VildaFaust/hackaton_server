using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using NewGame4.Commands.Base;
using Newtonsoft.Json;

namespace NewGame4.Commands.GameProcess
{
    public class IsGameCommand : ExecuteCommand
    {
        private string _userId { get; }
        private string _sessionId { get; }
        public IsGameCommand(IFormCollection data, HttpResponse response, HttpRequest request) : base(response, request)
        {
            NameCommand = nameof(IsGameCommand);
            _sessionId = data["sessionId"];
            _userId = data["userId"];
        }

        public override void Execute(ServerContext context)
        {
            var data = context.SessionModel.Get(_sessionId);
            var dataToUser = new Dictionary<string, object>();
            foreach (var camera in data.Cameras)
            {
                var localdata = new Dictionary<string, object>();
                localdata.Add("camera", Convert.ToBase64String(camera.Value.Camera));
                localdata.Add("X", camera.Value.X.ToString());
                localdata.Add("Y", camera.Value.Y.ToString());
                dataToUser.Add(camera.Key, localdata);
            }
            var sendObject = JsonConvert.SerializeObject(dataToUser);
            OverrideSend(sendObject);
        }

        private async void OverrideSend(string data)
        {
            await Response.WriteAsync(data);
        }
    }
}