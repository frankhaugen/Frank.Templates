using Frank.Templates.MonoGame;
using Frank.Templates.MonoGame.Extensions;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        context.HostingEnvironment.ContentRootPath = AppContext.BaseDirectory;
        
        services.AddGame(context.Configuration);
        services.AddHostedService<GameHost>();
    })
    .Build();

await host.RunAsync();