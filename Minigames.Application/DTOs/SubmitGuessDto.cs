namespace Minigames.Application.DTOs
{
    public record SubmitHangmanGuessDto(
        string PlayerName,
        char? Letter
    );
}