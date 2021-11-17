using Finance.Bot.Web.Configuration.Implementation;
using Finance.Bot.Web.Controllers;
using Finance.Bot.Web.Services.Implementation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Telegram.Bot;

namespace Finance.Bot.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            BotConfiguration = configuration.Get<BotConfiguration>();
        }

        public IConfiguration Configuration { get; }

        private BotConfiguration BotConfiguration { get; }

       public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(BotConfiguration);

            services.AddHostedService<ConfigureWebhookService>();

            services.AddHttpClient("tgwebhook")
                    .AddTypedClient<ITelegramBotClient>(httpClient
                        => new TelegramBotClient(BotConfiguration.Token, httpClient));

            services.AddControllers()
                .AddNewtonsoftJson();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "tgwebhook", pattern: $"bot/{BotConfiguration.Token}", new 
                { 
                    controller = nameof(WebhookController).Replace("Controller", string.Empty), 
                    action = nameof(WebhookController.OnUpdate) 
                });

                endpoints.MapControllers();
            });
        }
    }
}
