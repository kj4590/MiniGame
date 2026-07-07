using Minigames.Application.Interfaces;

namespace Minigames.Persistence.Services;

public class TextFileWordProvider : IWordProvider
{
    private readonly string[] _words;
    private readonly Random _random = new();

    public TextFileWordProvider()
    {
        var filePath = Path.Combine(AppContext.BaseDirectory, "Data", "words.txt");

        _words = File.ReadAllLines(filePath)
            .Where(w => !string.IsNullOrWhiteSpace(w))
            .Select(w => w.Trim().ToUpper())
            .ToArray();
    }

    public string GetRandomWord()
    {
        return _words[_random.Next(_words.Length)];
    }
}
