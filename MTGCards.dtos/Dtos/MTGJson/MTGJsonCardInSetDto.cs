namespace MTGCards.dtos.Dtos;

public interface IMTGJsonCardInSetDto
{
    string artist { get; set; }
    List<string> colors { get; set; }
    string name { get; set; }
    string text { get; set; }
}

public sealed class MtgJsonCardInSetDto : IMTGJsonCardInSetDto
{
    public string artist { get; set; }
    public List<string> availability { get; set; }
    public List<string> boosterTypes { get; set; }
    public string borderColor { get; set; }
    public List<string> colorIdentity { get; set; }
    public List<string> colors { get; set; }
    public float manaValue { get; set; }
    public List<string> keywords { get; set; }
    public string language { get; set; }
    public string layout { get; set; }
    public string manaCost { get; set; }
    public string name { get; set; }
    public string originalText { get; set; }
    public string originalType { get; set; }
    public string rarity { get; set; }
    public List<string> subTypes { get; set; }
    public List<string> superTypes { get; set; }
    public string text { get; set; }
    public string type { get; set; }
    public List<string> types { get; set; }
    public Guid uuid { get; set; }
}