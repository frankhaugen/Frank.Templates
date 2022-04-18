using CleanMonoGame;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<GameHost>();
    })
    .Build();

await host.RunAsync();
