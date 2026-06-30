namespace Minigames.Application.DTOs;

public record PlayerGameSummaryDto(int PlayerId)
{
    private HangmanGameResultDto hangmanGameResult = new HangmanGameResultDto();
    private FormulaGameResultDto formulaGameResult = new FormulaGameResultDto();

    public string PlayerName { get; set; } = string.Empty;
    public HangmanGameResultDto HangmanGameResult { get => HangmanGameResult1; set => HangmanGameResult1 = value; }

    public PlayerGameSummaryDto(int playerId, HangmanGameResultDto hangmanGameResult)
        : this(playerId)
    {
        HangmanGameResult = hangmanGameResult ?? throw new ArgumentNullException(nameof(hangmanGameResult));
    }

    public FormulaGameResultDto FormulaGameResult { get => formulaGameResult; set => formulaGameResult = value; }
    public HangmanGameResultDto HangmanGameResult1 { get => hangmanGameResult; set => hangmanGameResult = value; }
}