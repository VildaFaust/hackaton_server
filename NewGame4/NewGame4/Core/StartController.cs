using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using fastJSON;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using NewGame4.Commands;
using NewGame4.Decks;
using NewGame4.Sessions;
using NewGame4.Users;
using NewGame4.Utilities;
using Newtonsoft.Json;

namespace NewGame4.Core
{
    public class StartController
    {
        private readonly ServerContext _context;
        private ControllerCollection _controllerCollection = new ControllerCollection();
        private HttpContext _httpContext;

        public StartController(ServerContext context, HttpContext httpContext)
        {
            _context = context;
            _httpContext = httpContext;

            _context.BdConnection = new BdConnection();
            _context.BdConnection.Connect();
            
            CreateModels();
            CreateControllers();
            _controllerCollection.Activate();
        }

        private void CreateModels()
        {
            _context.CommandModel = new CommandModel();
            _context.Factory = new Factory(_context);
            _context.UserModel = new UserModel();
            _context.SessionModel = new SessionModel();
            _context.DeckModel = new DeckModel();
        }

        private void CreateControllers()
        {
            _controllerCollection.Add(new CommandController(_context, _context.CommandModel));
            _controllerCollection.Add(new UserController(_context, _context.UserModel));
            _controllerCollection.Add(new SessionController(_context, _context.SessionModel));
            _controllerCollection.Add(new DataObserver(_context, _context.UserModel));
        }
    }
}