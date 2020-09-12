using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using NewGame4.Commands.Base;
using NewGame4.Sessions;

namespace NewGame4.Commands.GameProcess
{
    public class SendUserVideoCommand : ExecuteCommand
    {
        private byte[] _video { get; }
        private int _x;
        private int _y;
        private string _userId;
        private string _sessionId;
        
        public SendUserVideoCommand(IFormCollection data, HttpResponse response, HttpRequest request) : base(response, request)
        {
            NameCommand = nameof(SendUserVideoCommand);
            _video = Convert.FromBase64String(data["video"]);
            _x = Convert.ToInt32(data["x"]);
            _y = Convert.ToInt32(data["y"]);

            _userId = data["userId"];
            _sessionId = data["sessionId"];
            
        }

        public override void Execute(ServerContext context)
        {
            var session = context.SessionModel.Get(_sessionId);
            if (session.Cameras.ContainsKey(_userId))
            {
                var camera = session.Cameras[_userId];
                camera.Camera = _video;
                camera.X = _x;
                camera.Y = _y;
            }
            else
            {
                var cameraData = new CameraData()
                {
                    Camera = _video,
                    X = _x,
                    Y = _y
                };
                session.Cameras.Add(_userId, cameraData);
            }
            Send();
        }
    }
}