using Minigames.Application.DTOs;
using Minigames.Application.Interfaces;

namespace Minigames.Application.Services
{
    public class LeaderboardService : ILeaderboardService
    {
        private readonly IPlayerRepository _playerRepository;

        public LeaderboardService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<IEnumerable<LeaderboardDto>> GetLeaderboardsAsync()
        {
            var players = await _playerRepository.GetAllPlayersAsync();

            var leaderboard = players.Select(player => new LeaderboardDto(
                player.PlayerName,
                player.GameSummary.TotalScore,
                "Total Score"))
                .OrderByDescending(dto => dto.Value)
                .Take(3)
                .ToList();

            return leaderboard;
        }

        public async Task<List<LeaderboardDto>> GetHangmanLeaderboardAsync()
        {
            var players = await _playerRepository.GetAllPlayersAsync();

            return players
                .OrderByDescending(p => p.GameSummary.HangmanGameResult.TimesWon)
                .Take(3)
                .Select(p => new LeaderboardDto(
                    p.PlayerName,
                    p.GameSummary.HangmanGameResult.TimesWon,
                    "Wins"))
                .ToList();
        }
    }
}