using Minigames.Domain.Enums;

namespace Minigames.Domain.Services;

public class HangmanScoringStrategy : IGameScoringStrategy
{
    private const int WinScore = 10;
    private const int LoseScore = 0;
    public MenuOption Game => MenuOption.Hangman;
    public int CalculateScore(GameResult result, int? difference = null)
    {
        return result == GameResult.Won ? WinScore : LoseScore;
    }
}
