using Microsoft.AspNetCore.Http;
using NewGame4.Commands.Base;

namespace NewGame4.Commands.Admin
{
    public class UploadCardCommand : ExecuteCommand
    {
        public UploadCardCommand(IFormCollection data, HttpResponse response, HttpRequest request) : base(response, request)
        {
            NameCommand = nameof(UploadCardCommand);
        }

        public override void Execute(ServerContext context)
        {
            
        }
    }
}