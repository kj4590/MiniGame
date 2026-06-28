using Minigames.Domain.Enums;

namespace Minigames.Domain.Services;
public interface IGameScoringStrategy
{
    MenuOption Game { get; }
    int CalculateScore(GameResult result, int? difference = null);
}