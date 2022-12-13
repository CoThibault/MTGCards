using MTGCards.lib.Models;
using MTGCards.lib.Services.Factories;

namespace MTGCards.lib.Services.Cards;

internal interface ICardsProvider
{
    IReadOnlyCollection<ICard> GetAllCardsFromSets();
}

internal sealed class CardsProvider : ICardsProvider
{
    private readonly ICardsDeserializer _cardsDeserializer;
    private readonly ICardsFactory _cardsFactory;

    public CardsProvider(ICardsDeserializer cardsDeserializer, ICardsFactory cardsFactory)
    {
        _cardsDeserializer = cardsDeserializer;
        _cardsFactory = cardsFactory;
    }

    /// <inheritdoc />
    public IReadOnlyCollection<ICard> GetAllCardsFromSets()
    {
        var dir = new DirectoryInfo(@"C:\Users\Thibault\Desktop\TMP\AllSetFiles");
        var cardsDto = _cardsDeserializer.DeserializeCardFromSets(dir).Values;
        return _cardsFactory.ConvertToModel(cardsDto);
    }
}