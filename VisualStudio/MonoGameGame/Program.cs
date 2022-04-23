using MonoGameGame;
using MonoGameGame.Extensions;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        Console.WriteLine(Directory.GetCurrentDirectory());
        Console.WriteLine(Environment.CurrentDirectory);
        Console.WriteLine(AppContext.BaseDirectory);
        Console.WriteLine(context.HostingEnvironment.ContentRootPath);
        services.AddGame(context.Configuration);
        services.AddHostedService<GameHost>();
    })
    .Build();

await host.RunAsync();
