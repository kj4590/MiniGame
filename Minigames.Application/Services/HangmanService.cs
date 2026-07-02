using Minigames.Application.DTOs;
using Minigames.Application.Interfaces;

namespace Minigames.Application.Services;

public class HangmanService : IHangmanGameService
{
    private const int MaxAttempts = 15;

    private readonly IWordProvider _wordProvider;
    private readonly Dictionary<string, HangmanGameSession> _gameSessions = new();

    public HangmanService(IWordProvider wordProvider)
    {
        _wordProvider = wordProvider ?? throw new ArgumentNullException(nameof(wordProvider));
    }

    public StartHangmanGameDto StartGame(string playerName)
    {
        // Create a new game session for this player (or reset if exists)
        var session = new HangmanGameSession
        {
            Word = _wordProvider.GetRandomWord(),
            GuessedLetters = new List<char>(),
            RemainingAttempts = MaxAttempts
        };

        _gameSessions[playerName] = session;

        return new StartHangmanGameDto(
            playerName,
            GetCurrentWord(session),
            session.RemainingAttempts,
            session.GuessedLetters
        );
    }

    public Task<HangmanAnswerResultDto> SubmitGuessAsync(SubmitGuessDto guess)
    {
        if (string.IsNullOrWhiteSpace(guess.PlayerName))
        {
            return Task.FromResult(new HangmanAnswerResultDto(
                "_ _ _ _ _ _ _ _",
                0,
                new List<char>(),
                "Player name is required.",
                false,
                true
            ));
        }

        if (!_gameSessions.ContainsKey(guess.PlayerName))
        {
            return Task.FromResult(new HangmanAnswerResultDto(
                "_ _ _ _ _ _ _ _",
                0,
                new List<char>(),
                "Game not started. Please start a new game first.",
                false,
                true
            ));
        }

        if (guess.Letter == null)
        {
            var session = _gameSessions[guess.PlayerName];
            return Task.FromResult(new HangmanAnswerResultDto(
                GetCurrentWord(session),
                session.RemainingAttempts,
                new List<char>(session.GuessedLetters),
                "Letter is required.",
                false,
                false
            ));
        }

        var gameSession = _gameSessions[guess.PlayerName];
        char letter = char.ToUpper(guess.Letter.Value);

        // Check if letter was already guessed
        if (gameSession.GuessedLetters.Contains(letter))
        {
            return Task.FromResult(new HangmanAnswerResultDto(
                GetCurrentWord(gameSession),
                gameSession.RemainingAttempts,
                new List<char>(gameSession.GuessedLetters),
                $"You already guessed '{letter}'. Try a different letter.",
                false,
                false
            ));
        }

        gameSession.GuessedLetters.Add(letter);

        // Check if letter is in the word
        if (!gameSession.Word.Contains(letter))
        {
            gameSession.RemainingAttempts--;
        }

        string currentWord = GetCurrentWord(gameSession);
        bool isWon = !currentWord.Contains('_');
        bool isGameOver = isWon || gameSession.RemainingAttempts <= 0;

        string message = isWon
            ? "Congratulations! You guessed the word."
            : isGameOver
                ? $"Game over. The word was {gameSession.Word}."
                : gameSession.Word.Contains(letter)
                    ? "Correct guess."
                    : "Wrong guess.";

        return Task.FromResult(new HangmanAnswerResultDto(
            currentWord,
            gameSession.RemainingAttempts,
            new List<char>(gameSession.GuessedLetters),
            message,
            isWon,
            isGameOver
        ));
    }

    private string GetCurrentWord(HangmanGameSession session)
    {
        return string.Join(" ", session.Word.Select(c =>
            session.GuessedLetters.Contains(c) ? c : '_'
        ));
    }

    // Inner class to track game session state
    private class HangmanGameSession
    {
        public string Word { get; set; } = string.Empty;
        public List<char> GuessedLetters { get; set; } = new();
        public int RemainingAttempts { get; set; }
    }
}