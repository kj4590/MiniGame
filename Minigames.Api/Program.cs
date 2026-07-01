using Microsoft.EntityFrameworkCore;
using Minigames.Application.Interfaces;
using Minigames.Application.Services;
using Minigames.Persistence.Data;
using Minigames.Persistence.Repositories;

public partial class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen();


        builder.Services.AddScoped<ILeaderboardService, LeaderboardService>();
        builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
        builder.Services.AddScoped<IPlayerService, PlayerService>();
        builder.Services.AddScoped<IFormulaGameService, FormulaGameService>();
        builder.Services.AddScoped<IHangmanGameService, HangmanService>();


        builder.Services.AddDbContext<MinigamesDbContext>(options =>
            options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")));

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.MapControllers();

        app.Run();
    }
}