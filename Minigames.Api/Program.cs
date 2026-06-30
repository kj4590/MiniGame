using Minigames.Application.Interfaces;
using Minigames.Infrastructure.Repositories;

public partial class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddSwaggerGen();

        builder.Services.AddEndpointsApiExplorer();


        builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
        builder.Services.AddScoped<IPlayerService, PlayerService>();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.MapGet("/", () => "Minigames API is running!");

        app.Run();
    }
}