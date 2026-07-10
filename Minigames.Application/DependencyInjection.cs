using Microsoft.Extensions.DependencyInjection;
using Minigames.Application.Interfaces;
using Minigames.Application.Services;

namespace Minigames.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddSingleton<IHangmanGameService, HangmanService>();
        services.AddScoped<ILeaderboardService, LeaderboardService>();
        services.AddScoped<IPlayerService, PlayerService>();
        services.AddScoped<IFormulaGameService, FormulaGameService>();

        return services;
    }
}