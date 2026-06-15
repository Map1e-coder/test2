namespace ChordProgressionApp;

internal sealed class ChordProgressionGenerator
{
    private const int ProgressionLength = 4;

    private static readonly string[] Chords =
    [
        "C",
        "Cmaj7",
        "Cadd9",
        "Dm",
        // "Dmadd9",
        "Em",
        "F",
        "Fmaj7",
        "Fadd9",
        "G",
        "G7",
        // "Gadd9",
        "Am",
        // "Amadd9"
    ];

    public IReadOnlyList<string> Generate()
    {
        var shuffled = Chords.ToArray();

        for (var index = shuffled.Length - 1; index > 0; index--)
        {
            var swapIndex = Random.Shared.Next(index + 1);
            (shuffled[index], shuffled[swapIndex]) = (shuffled[swapIndex], shuffled[index]);
        }

        return shuffled[..ProgressionLength];
    }
}
