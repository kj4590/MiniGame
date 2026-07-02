namespace Minigames.Application.DTOs;

public record SubmitGuessDto(
    string PlayerName,
    char? Letter
);