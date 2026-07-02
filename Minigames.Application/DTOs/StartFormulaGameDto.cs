namespace Minigames.Application.DTOs
{

    public record StartFormulaGameDto(
        string PlayerName,
        List<int> Numbers,
        int Target
        );

    public record FormulaAnswerResultDto(
        int Result,
        int Difference,
        string Message
        );
}