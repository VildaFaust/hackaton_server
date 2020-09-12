using System;
using System.Collections.Generic;
using System.IO;
using fastJSON;
using Microsoft.AspNetCore.Http;
using NewGame4.Commands.Base;
using NewGame4.Decks;
using NewGame4.Utilities;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using Newtonsoft.Json;
using SixLabors.ImageSharp.Processing;

namespace NewGame4.Commands.Admin
{
    public class UploadDeckCommand : ExecuteCommand
    {
        private Dictionary<string, object> _cards { get; }

        public UploadDeckCommand(IFormCollection data, HttpResponse response, HttpRequest request) : base(response,
            request)
        {
            NameCommand = nameof(UploadDeckCommand);
            _cards = (Dictionary<string, object>) JSON.Parse(data["json"]);
        }

        public override void Execute(ServerContext context)
        {
            var name = _cards.GetString("name");
            var shirt = _cards.GetString("shirt");
            var cards = _cards.GetNode("cards");

            
            FileHelper.CreateDirectory($"{name}"); 
            FileHelper.CreateDirectory("Resources/Decks");

            foreach (var card in cards)
            {
                Console.WriteLine(card.Key);
                
                var writePath = $"{name}/{card.Key}.jpeg";

                using (StreamWriter sw = new StreamWriter($"Resources/Decks/{name}.json", false, System.Text.Encoding.Default))
                {
                    string json = JsonConvert.SerializeObject(_cards, Formatting.Indented);
                    sw.WriteLine(json);
                }

                Image<Rgba32> image = Image.Load(Convert.FromBase64String(card.Value.ToString()!));
                image.Mutate(x => x.Resize(new Size(1280, 960)));
                
                try
                {
                    using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                    {
                            sw.WriteLine(image);
                    }
                    UserParams.Add("image",card.Value);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                
                var deck = new DeckUnitModel()
                {
                    Name = name,
                    Shirt = shirt,
                    Cards = cards
                };
                context.DeckModel.Add(deck);                
            }
            Send();
        }
    }
}