using Minigames.Application.DTOs;
using Minigames.Application.Interfaces;

namespace Minigames.Application.Services;

public class LeaderboardService : ILeaderboardService
{
        private readonly IPlayerRepository _playerRepository;

        public LeaderboardService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<IEnumerable<LeaderboardDto>> GetLeaderboardAsync()
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

        public async Task<List<LeaderboardDto>> GetFormulaLeaderboardAsync()
        {
            var players = await _playerRepository.GetAllPlayersAsync();

            return players
                .Where(p=> p.GameSummary.FormulaGameResult.BestDifference.HasValue)
                .OrderBy(p=>p.GameSummary.FormulaGameResult.BestDifference)
                .Take(3)
                .Select(p => new LeaderboardDto(
                    p.PlayerName,
                    p.GameSummary.FormulaGameResult.BestDifference??0,
                    "Best Difference"))
                .ToList();
        }
    }