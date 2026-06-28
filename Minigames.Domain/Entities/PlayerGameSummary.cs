namespace Minigames.Domain.Entities;

public class PlayerGameSummary
{
    public HangmanGameResult hangmanGameResult { get; private set; }

    public FormulaGameResult formulaGameResult { get; private set; }

    public PlayerGameSummary()
    {
        hangmanGameResult = new HangmanGameResult();
        formulaGameResult = new FormulaGameResult();
    }
}