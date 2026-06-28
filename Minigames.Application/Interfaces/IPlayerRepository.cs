using Minigames.Domain.Entities;

namespace Minigames.Application.Interfaces
{
    public interface IPlayerRepository
    {
        Task<Player?> GetPlayerByNameAsync(string playerName);
        Task<IEnumerable<Player>> GetAllPlayersAsync();
        Task AddPlayerAsync(Player player);
    }
}