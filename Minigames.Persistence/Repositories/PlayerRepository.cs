using Microsoft.EntityFrameworkCore;
using Minigames.Application.Interfaces;
using Minigames.Domain.Entities;
using Minigames.Persistence.Data;

namespace Minigames.Persistence.Repositories;

public class PlayerRepository : IPlayerRepository
{
        private readonly MinigamesDbContext _context;

        public PlayerRepository(MinigamesDbContext context)
        {
            _context = context;
        }

        public async Task<Player?> GetPlayerByNameAsync(string playerName)
        {
        return await _context.Players
            .Include(p => p.GameSummary)
                .ThenInclude(gs => gs.FormulaGameResult)
            .Include(p => p.GameSummary)
                .ThenInclude(gs => gs.HangmanGameResult)
            .FirstOrDefaultAsync(p => p.PlayerName == playerName);
                }

        public async Task<IEnumerable<Player>> GetAllPlayersAsync()
        {
            return await _context.Players.ToListAsync();
        }

        public async Task AddPlayerAsync(Player player)
        {
            _context.Players.Add(player);
            await _context.SaveChangesAsync();
        }

            public async Task SaveChangesAsync()
            {
                await _context.SaveChangesAsync();
            }
        }