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

            services.AddOption<GameOptions, PlayerOptions>(configuration);

            return services;
        }

        internal static IServiceCollection AddOption<TOption>(this IServiceCollection services, IConfiguration configuration) where TOption : class
        {
            services.Configure<TOption>(configuration.GetSection(typeof(TOption).Name));
            
            return services;
        }

        internal static IServiceCollection AddOption<TOption, TOption2>(this IServiceCollection services, IConfiguration configuration) where TOption : class
        {
            services.Configure<TOption>(configuration.GetSection(typeof(TOption).Name));
            services.Configure<TOption>(configuration.GetSection(typeof(TOption2).Name));
            
            return services;
        }

        internal static IServiceCollection AddOption<TOption, TOption2, TOption3>(this IServiceCollection services, IConfiguration configuration) where TOption : class
        {
            services.Configure<TOption>(configuration.GetSection(typeof(TOption).Name));
            services.Configure<TOption>(configuration.GetSection(typeof(TOption2).Name));
            services.Configure<TOption>(configuration.GetSection(typeof(TOption3).Name));
            
            return services;
        }

        internal static IServiceCollection AddOption<TOption, TOption2, TOption3, TOption4>(this IServiceCollection services, IConfiguration configuration) where TOption : class
        {
            services.Configure<TOption>(configuration.GetSection(typeof(TOption).Name));
            services.Configure<TOption>(configuration.GetSection(typeof(TOption2).Name));
            services.Configure<TOption>(configuration.GetSection(typeof(TOption3).Name));
            services.Configure<TOption>(configuration.GetSection(typeof(TOption4).Name));
            
            return services;
        }

        internal static IServiceCollection AddOption<TOption, TOption2, TOption3, TOption4, TOption5>(this IServiceCollection services, IConfiguration configuration) where TOption : class
        {
            services.Configure<TOption>(configuration.GetSection(typeof(TOption).Name));
            services.Configure<TOption>(configuration.GetSection(typeof(TOption2).Name));
            services.Configure<TOption>(configuration.GetSection(typeof(TOption3).Name));
            services.Configure<TOption>(configuration.GetSection(typeof(TOption4).Name));
            services.Configure<TOption>(configuration.GetSection(typeof(TOption5).Name));
			
            return services;
        }

        internal static IServiceCollection AddOption<TOption, TOption2, TOption3, TOption4, TOption5, TOption6>(this IServiceCollection services, IConfiguration configuration) where TOption : class
        {
            services.Configure<TOption>(configuration.GetSection(typeof(TOption).Name));
            services.Configure<TOption>(configuration.GetSection(typeof(TOption2).Name));
            services.Configure<TOption>(configuration.GetSection(typeof(TOption3).Name));
            services.Configure<TOption>(configuration.GetSection(typeof(TOption4).Name));
            services.Configure<TOption>(configuration.GetSection(typeof(TOption5).Name));
            services.Configure<TOption>(configuration.GetSection(typeof(TOption6).Name));
			
            return services;
        }

        internal static IServiceCollection AddOption<TOption, TOption2, TOption3, TOption4, TOption5, TOption6, TOption7>(this IServiceCollection services, IConfiguration configuration) where TOption : class
        {
            services.Configure<TOption>(configuration.GetSection(typeof(TOption).Name));
            services.Configure<TOption>(configuration.GetSection(typeof(TOption2).Name));
            services.Configure<TOption>(configuration.GetSection(typeof(TOption3).Name));
            services.Configure<TOption>(configuration.GetSection(typeof(TOption4).Name));
            services.Configure<TOption>(configuration.GetSection(typeof(TOption5).Name));
            services.Configure<TOption>(configuration.GetSection(typeof(TOption6).Name));
            services.Configure<TOption>(configuration.GetSection(typeof(TOption7).Name));
			
            return services;
        }
    }
}
