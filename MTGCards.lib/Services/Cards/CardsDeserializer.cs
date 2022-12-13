using MTGCards.dtos;
using MTGCards.dtos.Dtos;
using Newtonsoft.Json;

namespace MTGCards.lib.Services.Cards;

internal interface ICardsDeserializer
{
    IReadOnlyDictionary<string, IReadOnlyCollection<MtgJsonCardInSetDto>> DeserializeCardFromSets(DirectoryInfo setsDirectory);
}

internal sealed class CardsDeserializer : ICardsDeserializer
{
    /// <param name="setsDirectory"></param>
    /// <inheritdoc />
    public IReadOnlyDictionary<string, IReadOnlyCollection<MtgJsonCardInSetDto>> DeserializeCardFromSets(DirectoryInfo setsDirectory)
    {
        var sets = new Dictionary<string, IReadOnlyCollection<MtgJsonCardInSetDto>>();
        
        foreach (var setFile in setsDirectory.GetFiles())
        {
            var res = JsonConvert.DeserializeObject<MTGJsonSetDto>(File.ReadAllText(setFile.FullName));
            sets.Add(res.data.name, res.data.cards);
        }

        return sets;
    }
}