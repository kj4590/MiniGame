using Minigames.Application.DTOs;

namespace Minigames.Application.Interfaces;

public interface IPlayerService
{
    Task<PlayerDto> CreatePlayerAsync(CreatePlayerDto createPlayerDto);
    Task<PlayerDto> GetPlayerByNameAsync(string playerName);
    Task<PlayerGameSummaryDto?> GetPlayerGameSummaryAsync(string playerName);
    Task RecordHangmanGameAsync(string playerName, bool won);
    Task RecordFormulaGameAsync(string playerName, int difference);
}