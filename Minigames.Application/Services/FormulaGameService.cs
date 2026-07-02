using System.Data;
using System.Text.RegularExpressions;
using Minigames.Application.DTOs;
using Minigames.Application.Interfaces;

namespace Minigames.Application.Services;

public class FormulaGameService : IFormulaGameService
{
        private readonly IPlayerRepository _playerRepository;
        private readonly List<int> _numbersInFormula = new List<int> { 2, 5, 8, 10, 25, 50 };
        private const int Target = 532;

        public FormulaGameService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository ?? throw new ArgumentNullException(nameof(playerRepository));
        }

        public StartFormulaGameDto StartGame(string playerName)
        {
            return new StartFormulaGameDto
            (
                playerName,
                _numbersInFormula,
                Target
            );
        }

        public async Task<FormulaAnswerResultDto> SubmitFormulaAnswerAsync(SubmitFormulaAnswerDto _answer)
        {
            if (_answer == null)
                throw new ArgumentNullException(nameof(_answer));

            if (string.IsNullOrWhiteSpace(_answer.Expression))
            {
                throw new ArgumentException("Expression cannot be empty.");
            }

            if (!Regex.IsMatch(_answer.Expression, @"^[0-9+\-*/\s()]+$"))
                throw new ArgumentException("Expression contains invalid characters. (No alphabets, only digits and operators +/-/*() )");

            var numbersUsed = Regex.Matches(_answer.Expression, @"\d+").Select(match => int.Parse(match.Value)).ToList();

            var availableNumbers = new List<int>(_numbersInFormula);

            foreach (int number in numbersUsed)
            {
                if (!availableNumbers.Contains(number))
                    throw new ArgumentException($"You cannot use numbers that are outside the provided list: {string.Join(",", _numbersInFormula)}");

                availableNumbers.Remove(number);
            }

            int result;

            try
            {
                result = Convert.ToInt32(new DataTable().Compute(_answer.Expression, null));
            }
            catch
            {
                throw new ArgumentException("Invalid mathematical expression.");
            }

            int difference = Math.Abs(Target - result);

            string message = difference switch
            {
                0 => "Perfect match, you found the exact solution",
                <= 10 => "Great job! You're very close to the target.",
                _ => "Nice try!"
            };

        var player = await _playerRepository.GetPlayerByNameAsync(_answer.PlayerName);

        if (player == null)
        {
            throw new ArgumentException(
                $"Player '{_answer.PlayerName}' not found.");
        }

        player.GameSummary.FormulaGameResult.RecordGame(difference);

        await _playerRepository.SaveChangesAsync();

        return new FormulaAnswerResultDto(
                result,
                difference,
                message
            );
        }
    }