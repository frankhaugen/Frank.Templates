using MonoGame.Extended.Input.InputListeners;
using MonoGameTemplate.Models.Configuration;

namespace MonoGameTemplate.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        internal static IServiceCollection AddGame(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IGameWindow, GameWindow>();
            services.AddSingleton<IInputService, InputService>();
            services.AddSingleton<IDrawer, Drawer>();

            services.Configure<GameState>(delegate(GameState state) {  });
            services.Configure<GameOptions>(configuration.GetSection(nameof(GameOptions)));
            services.Configure<PlayerOptions>(configuration.GetSection(nameof(PlayerOptions)));

            return services;
        }
    }
}
