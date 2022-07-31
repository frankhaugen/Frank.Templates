using MonoGameTemplate;
using MonoGameTemplate.Extensions;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        context.HostingEnvironment.ContentRootPath = AppContext.BaseDirectory;
        Console.WriteLine($"Set {nameof(context.HostingEnvironment.ContentRootPath)} to '{context.HostingEnvironment.ContentRootPath}'");
        services.AddGame(context.Configuration);
        services.AddHostedService<GameHost>();
    })
    .Build();

await host.RunAsync();