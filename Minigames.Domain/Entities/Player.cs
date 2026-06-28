namespace Minigames.Domain.Entities;

public class Player
{
    public int Id { get; set; }
    public string PlayerName { get; private set; }
    public PlayerGameSummary GameSummary { get; private set; }

    public Player(string playerName)
    {
        if (string.IsNullOrWhiteSpace(playerName))
            throw new ArgumentException("Username cannot be blank");

        PlayerName = playerName.Trim();
        GameSummary = new PlayerGameSummary();
    }
}