using Minigames.Application.DTOs;
using Minigames.Application.Interfaces;
using Minigames.Domain.Entities;

namespace Minigames.Application.Services
{
    public class PlayerService(IPlayerRepository playerRepository) : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository = playerRepository;

        public async Task<PlayerDto> CreatePlayerAsync(CreatePlayerDto createPlayerDto)
        {
            var player = new Player(createPlayerDto.PlayerName);

            await
                _playerRepository.AddPlayerAsync(player);

            return new PlayerDto { PlayerName = player.PlayerName };
        }

        public async Task<PlayerDto> GetPlayerByNameAsync(string playerName)
        {
            if (string.IsNullOrWhiteSpace(playerName))
                throw new ArgumentException("Player name must not be empty.", nameof(playerName));

            var player = await _playerRepository.GetPlayerByNameAsync(playerName);
            if (player == null)
                throw new KeyNotFoundException($"Player '{playerName}' not found.");

            return new PlayerDto
            {
                Id = player.Id,
                PlayerName = player.PlayerName
            };
        }

        public async Task<PlayerGameSummaryDto?> GetPlayerGameSummaryAsync(string playerName)
        {
            if (string.IsNullOrWhiteSpace(playerName))
                throw new ArgumentException("Player name must not be empty.", nameof(playerName));

            var player = await _playerRepository.GetPlayerByNameAsync(playerName);
            if (player == null)
                return null;

            var summary = new PlayerGameSummaryDto(player.Id)
            {
                PlayerName = player.PlayerName,
                HangmanGameResult = player.GameSummary?.HangmanGameResult,
                FormulaGameResult = player.GameSummary?.FormulaGameResult
            };
            return summary;
        }
    }
}