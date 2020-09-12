using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using NewGame4.Commands;
using NewGame4.Commands.Base;
using NewGame4.Commands.GameElements;
using NewGame4.Commands.GameProcess;
using NewGame4.Commands.GamingFields;
using NewGame4.Commands.Registration;
using NewGame4.Commands.SignIn_SignOut;
using NewGame4.Commands.Subscription;
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
                {nameof(LeaderBuySubscriptionCommand), (form, response, request) => new LeaderBuySubscriptionCommand(form, response, request)},
                {nameof(RegistrationCommand), (form, response, request) => new RegistrationCommand(form, response, request)},
                {nameof(GamingFieldSectionNowPlayingCommand), (form, response, request) => new GamingFieldSectionNowPlayingCommand(form, response, request)},
                {nameof(LeaderDistributeTreasuryCommand), (form, response, request) => new LeaderDistributeTreasuryCommand(form, response, request)},
                {nameof(CreateNewGameCommand), (form, response, request) => new CreateNewGameCommand(form, response, request)},
                {nameof(BagFillingCommand), (form, response, request) => new BagFillingCommand(form, response, request)},
                {nameof(FormingGiftOfTheUniverseCommand), (form, response, request) => new FormingGiftOfTheUniverseCommand(form, response, request)},
                {nameof(FormingGamingSectorCommand), (form, response, request) => new FormingGamingSectorCommand(form, response, request)},
                {nameof(FormingCoffersCommand), (form, response, request) => new FormingCoffersCommand(form, response, request)},
                {nameof(DecomposedElementsCommand), (form, response, request) => new DecomposedElementsCommand(form, response, request)},
                {nameof(UserConnectionCommand), (form, response, request) => new UserConnectionCommand(form, response, request)},
                {nameof(GetPricingCommand), (form, response, request) => new GetPricingCommand(form, response, request)},
                {nameof(SendUserVideoCommand), (form, response, request) => new SendUserVideoCommand(form, response, request)},
                {nameof(ScreenChangedCommand), (form, response, request) => new ScreenChangedCommand(form, response, request)},
                {nameof(PlayerEnterCommand), (form, response, request) => new PlayerEnterCommand(form, response, request)},
                {nameof(IsGameCommand), (form, response, request) => new IsGameCommand(form, response, request)},
            };
        }
    }
}