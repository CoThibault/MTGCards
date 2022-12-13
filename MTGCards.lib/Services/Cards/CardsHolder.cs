using MTGCards.lib.Models;

namespace MTGCards.lib.Services.Cards;

internal interface ICardsHolder
{
    IReadOnlyCollection<ICard> GetAllCardsFromSets();
}

internal sealed class CardsHolder : ICardsHolder
{
    private readonly ICardsProvider _cardsProvider;

    public CardsHolder(ICardsProvider cardsProvider)
    {
        _cardsProvider = cardsProvider;
    }

    /// <inheritdoc />
    public IReadOnlyCollection<ICard> GetAllCardsFromSets()
    {
        return _cardsProvider.GetAllCardsFromSets();
    }
}