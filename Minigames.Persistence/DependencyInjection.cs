using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Minigames.Application.Interfaces;
using Minigames.Persistence.Data;
using Minigames.Persistence.Repositories;

using Minigames.Persistence.Services;

namespace Minigames.Persistence;
public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<MinigamesDbContext>(options =>
           options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IPlayerRepository, PlayerRepository>();
        services.AddSingleton<IWordProvider, TextFileWordProvider>();

        return services;
    }
}