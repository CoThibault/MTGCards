using System.Collections.Generic;
using MTGCards.gui.Adapters;
using MTGCards.lib.Models;

namespace MTGCards.gui.Factories;

internal interface ICardAdapterFactory
{
    IReadOnlyCollection<ICardAdapter> GetCardsAdaptersFromCards(IReadOnlyCollection<ICard> cards);
}

internal sealed class CardAdapterFactory : ICardAdapterFactory
{
    /// <inheritdoc />
    public IReadOnlyCollection<ICardAdapter> GetCardsAdaptersFromCards(IReadOnlyCollection<ICard> cards)
    {
        var cardsAdapter = new List<ICardAdapter>();
        foreach (var card in cards)
        {
            cardsAdapter.Add(new CardAdapter(card.CardName, card.ArtistName, card.CardColors, card.Description));
        }

        return cardsAdapter;
    }
}