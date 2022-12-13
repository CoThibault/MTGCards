using MTGCards.dtos.Dtos;

namespace MTGCards.dtos;

public sealed class MTGJsonDataDto
{
    public List<MtgJsonCardInSetDto> cards { get; set; }
    public string name { get; set; }
}