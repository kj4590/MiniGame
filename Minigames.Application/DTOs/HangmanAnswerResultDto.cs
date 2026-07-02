namespace Minigames.Application.DTOs;

public record HangmanAnswerResultDto(
    string CurrentWord,
    int RemainingAttempts,
    List<char> GuessedLetters,
    string Message,
    bool IsWon,
    bool IsGameOver
);