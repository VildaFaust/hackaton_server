using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NewGame4.Core;

namespace NewGame4
{
    public class Startup
    {
        public HttpContext HttpContext;
        public ServerContext Context;
        public StartController StartController;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(allowsites=>{allowsites.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });
        }

        public void Configure(IApplicationBuilder app)
        {
            Context = new ServerContext();
            StartController = new StartController(Context, HttpContext);

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();
            
            app.UseCors(options => options.AllowAnyOrigin());

            app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/game_request")
                {
                    if (!context.Request.HasFormContentType)
                    {
                        context.Response.Redirect("/");
                    }
                    else
                    {
                        var test = context.Request.Query;
                        Context.CommandModel.AddCommand(Context.Factory.CommandFactory[context.Request.Form["Command"]](context.Request.Form, context.Response, context.Request));
                    }
                }
                else
                {
                    await next();
                }
            });
        }
    }
}