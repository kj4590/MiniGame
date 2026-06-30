using Minigames.Application.Interfaces;
using Minigames.Domain.Entities;

namespace Minigames.Infrastructure.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {

        private static List<Player> players = [];

        public static List<Player> Players { get => players; set => players = value; }

        public Task<Player?> GetPlayerByNameAsync(string playerName)
        {
            return Task.FromResult(Players.FirstOrDefault(p => p.PlayerName == playerName));
        }

        public Task<IEnumerable<Player>> GetAllPlayersAsync()
        {
            return Task.FromResult(Players.AsEnumerable());
        }

        public Task AddPlayerAsync(Player player)
        {
            Players.Add(player);
            return Task.CompletedTask;
        }
    }
}