using Minigames.Application.DTOs;

namespace Minigames.Application.Interfaces
{
    public interface ILeaderboardService
    {
        Task<IEnumerable<LeaderboardDto>> GetLeaderboardAsync();

        Task<List<LeaderboardDto>> GetHangmanLeaderboardAsync();

        Task<List<LeaderboardDto>> GetFormulaLeaderboardAsync();
    }
}
