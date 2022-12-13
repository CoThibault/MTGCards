namespace MTGCards.lib.Models;

internal interface ICard
{
    public string ArtistName { get; }
    public string CardName { get; }
    public List<string> CardColors { get; }
    public string Description { get; }
}

internal sealed class Card : ICard
{
    public Card(string artistName, string cardName, List<string> cardColors, string description)
    {
        ArtistName = artistName;
        CardName = cardName;
        CardColors = cardColors;
        Description = description;
    }

    public string Description { get; }

    /// <inheritdoc />
    public string ArtistName { get; }

    /// <inheritdoc />
    public string CardName { get; }

    /// <inheritdoc />
    public List<string> CardColors { get; }
}