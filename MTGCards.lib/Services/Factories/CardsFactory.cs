using MTGCards.dtos.Dtos;
using MTGCards.lib.Models;

namespace MTGCards.lib.Services.Factories;

internal interface ICardsFactory
{
    IReadOnlyCollection<ICard> ConvertToModel(IEnumerable<IReadOnlyCollection<IMTGJsonCardInSetDto>> cardsDtoSets);
}

internal sealed class CardsFactory : ICardsFactory
{
    /// <inheritdoc />
    public IReadOnlyCollection<ICard> ConvertToModel(IEnumerable<IReadOnlyCollection<IMTGJsonCardInSetDto>> cardsDtoSets)
    {
        var cards = new List<ICard>();
        foreach (var cardDtoSet in cardsDtoSets)
        {
            foreach (var cardDto in cardDtoSet)
            {
                cards.Add(new Card(cardDto.artist, cardDto.name, cardDto.colors, cardDto.text));
            }
        }
        return cards;
    }
}