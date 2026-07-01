using Microsoft.EntityFrameworkCore;
using Minigames.Application.Interfaces;
using Minigames.Domain.Entities;
using Minigames.Infrastructure.Data;

namespace Minigames.Infrastructure.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly MinigamesDbContext _context;

        public PlayerRepository(MinigamesDbContext context)
        {
            _context = context;
        }

        public async Task<Player?> GetPlayerByNameAsync(string playerName)
        {
            return await _context.Players.FirstOrDefaultAsync(p => p.PlayerName == playerName);
        }

        public Task<IEnumerable<Player>> GetAllPlayersAsync()
        {
            return Task.FromResult(_context.Players.AsEnumerable());
        }

        public Task AddPlayerAsync(Player player)
        {
            _context.Players.Add(player);
            return Task.CompletedTask;
        }
    }
}