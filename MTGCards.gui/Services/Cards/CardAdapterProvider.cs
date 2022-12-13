using System.Collections.Generic;
using MTGCards.gui.Adapters;
using MTGCards.gui.Factories;
using MTGCards.lib.Services.Cards;

namespace MTGCards.gui.Services.Cards;

internal interface ICardAdapterProvider
{
    IReadOnlyCollection<ICardAdapter> GetCardAdaptersFromSets();
}

internal sealed class CardAdapterProvider : ICardAdapterProvider
{
    private readonly ICardsHolder _cardsHolder;
    private readonly ICardAdapterFactory _cardAdapterFactory;

    public CardAdapterProvider(ICardsHolder cardsHolder, ICardAdapterFactory cardAdapterFactory)
    {
        _cardsHolder = cardsHolder;
        _cardAdapterFactory = cardAdapterFactory;
    }
    
    /// <inheritdoc />
    public IReadOnlyCollection<ICardAdapter> GetCardAdaptersFromSets()
    {
        var cards = _cardsHolder.GetAllCardsFromSets();
        return _cardAdapterFactory.GetCardsAdaptersFromCards(cards);
    }
}