namespace Minigames.Application.DTOs;

public class PlayerGameSummaryDto
{
    public int PlayerId { get; set; }
    public string PlayerName { get; set; } = string.Empty;
    public HangmanGameResultDto HangmanGameResult { get; set; } = new HangmanGameResultDto();
    public FormulaGameResultDto FormulaGameResult { get; set; } = new FormulaGameResultDto();
}