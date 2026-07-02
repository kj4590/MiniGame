using Minigames.Application.DTOs;
using Minigames.Application.Interfaces;
using Microsoft.AspNetCore.Hosting;

namespace Minigames.Application.Services;

public class HangmanService : IHangmanGameService
{
    private const int MaxAttempts = 15;

    private readonly List<char> _guessedLetters = new();

    private int _remainingAttempts = MaxAttempts;

    private readonly string _word;

    public HangmanService(IWordProvider wordProvider)
    {
        _wordProvider = wordProvider;
    }
    public StartHangmanGameDto StartGame(string playerName)
    {
        _guessedLetters.Clear();
        _remainingAttempts = MaxAttempts;

        return new StartHangmanGameDto(playerName, GetCurrentWord(), _remainingAttempts);
    }

    public Task<HangmanAnswerResultDto> SubmitGuessAsync(SubmitHangmanGuessDto guess)
    {
        char letter = char.ToUpper(guess.Letter);

        _guessedLetters.Add(letter);

        if (!_wordProvider.Contains(letter))
        {
            _remainingAttempts--;
        }

        string currentWord = GetCurrentWord();

        bool isWon = !currentWord.Contains('_');

        bool isGameOver = isWon || _remainingAttempts <= 0;

        string message = isWon
            ? "Congratulations! You guessed the word."
            : isGameOver
                ? $"Game over. The word was {_word}."
                : _word.Contains(letter)
                    ? "Correct guess."
                    : "Wrong guess.";

        return Task.FromResult(
            new HangmanAnswerResultDto( currentWord, _remainingAttempts, _guessedLetters, message, isWon, isGameOver));
    }

    private string GetCurrentWord()
    {
        return string.Join(" ",
            _word.Select(c =>
                _guessedLetters.Contains(c)
                    ? c
                    : '_'));
    }
}