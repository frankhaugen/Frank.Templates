using MonoGameGame.Models.Configuration;

namespace MonoGameGame.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        internal static IServiceCollection AddGame(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IGameWindow, GameWindow>();

            services.Configure<GameOptions>(configuration.GetSection(nameof(GameOptions)));
            services.Configure<PlayerOptions>(configuration.GetSection(nameof(PlayerOptions)));

            return services;
        }
    }
}
