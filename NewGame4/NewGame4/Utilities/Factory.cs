using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using NewGame4.Commands;
using NewGame4.Commands.Base;
using NewGame4.Commands.Registration;
using NewGame4.Commands.SignIn_SignOut;
using NewGame4.Commands.UtilityCommands;

namespace NewGame4.Utilities
{
    public class Factory
    {
        public Dictionary<string, Func<IFormCollection, HttpResponse, HttpRequest, IExecuteCommand>> CommandFactory;
        private ServerContext _context;

        public Factory(ServerContext context)
        {
            _context = context;
            CommandFactory = new Dictionary<string, Func<IFormCollection, HttpResponse, HttpRequest, IExecuteCommand>>
            {
                {nameof(UserSignInCommand), (form, response, request) => new UserSignInCommand(form, response, request)},
                {nameof(SignOutCommand), (form, response, request) => new SignOutCommand(form, response, request)},
                {nameof(RegistrationCommand), (form, response, request) => new RegistrationCommand(form, response, request)},
                {nameof(UserConnectionCommand), (form, response, request) => new UserConnectionCommand(form, response, request)},
                {nameof(ScreenChangedCommand), (form, response, request) => new ScreenChangedCommand(form, response, request)},
                {nameof(PlayerEnterCommand), (form, response, request) => new PlayerEnterCommand(form, response, request)},
            };
        }
    }
}