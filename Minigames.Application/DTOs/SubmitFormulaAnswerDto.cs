namespace Minigames.Application.DTOs
{
    public record SubmitFormulaAnswerDto : IEquatable<SubmitFormulaAnswerDto>
    {
        public string? PlayerName { get; init; }
        public string? Expression { get; init; }
    }
}
