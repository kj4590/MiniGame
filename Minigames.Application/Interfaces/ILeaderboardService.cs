using Minigames.Application.DTOs;

namespace Minigames.Application.Interfaces
{
    public interface ILeaderboardService
    {
        Task<IEnumerable<LeaderboardDto>> LeaderboardAsync { get;}
    }
}
