using Minigames.Domain.Entities;

namespace Minigames.Application.Interfaces
{
    public interface IPlayerService
    {
        Task<PlayerDto> CreatePlayerAsync(CreatePlayerDto createPlayerDto);
        Task<PlayerDto> GetPlayerByNameAsync(string playerName);
        Task<PlayerGameSummaryDto?> GetPlayerGameSummaryAsync(string playerName);
    }
}