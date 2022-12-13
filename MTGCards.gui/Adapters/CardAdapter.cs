using System.Collections.Generic;
using System.Windows.Media;
using MTGCards.gui.Services.Cards.Helpers;

namespace MTGCards.gui.Adapters;

internal interface ICardAdapter
{
    string CardName { get; }
    string ArtistName { get; }
    IReadOnlyCollection<string> CardColors { get; }
    string Description { get; }
    public Brush CardsColorsToDisplay { get; }
}

internal sealed class CardAdapter : ICardAdapter
{
    public CardAdapter(string cardName, string artistName, IReadOnlyCollection<string> cardColors, string description)
    {
        CardName = cardName;
        ArtistName = artistName;
        CardColors = cardColors;
        Description = description;
    }

    /// <inheritdoc />
    public string CardName { get; }

    /// <inheritdoc />
    public string ArtistName { get; }

    /// <inheritdoc />
    public IReadOnlyCollection<string> CardColors { get; }

    /// <inheritdoc />
    public string Description { get; }

    /// <inheritdoc />
    public Brush CardsColorsToDisplay => CardAdapterColorHelper.GetBorderColorForAdapter();
}