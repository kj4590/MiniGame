using Minigames.Domain.Enums;

namespace Minigames.Domain.Services;

public class  FormulaScoringStrategy : IGameScoringStrategy
{
    public MenuOption Game => MenuOption.Formula;

    public int CalculateScore(GameResult result, int? difference = null)
    {
        return result switch
        {
            GameResult.Won => 10,
            GameResult.CloseGuess => 5,
            GameResult.lose => 0
        };
    }
}