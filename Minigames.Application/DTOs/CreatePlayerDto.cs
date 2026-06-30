using System.ComponentModel.DataAnnotations;

namespace Minigames.Application.DTOs;

public class CreatePlayerDto
{
    [Required(ErrorMessage = "Player name cannot be blank")]
    public string PlayerName { get; init; } = string.Empty;
}