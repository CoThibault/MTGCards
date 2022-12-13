namespace MTGCards.dtos.Dtos.Scryfall;


public sealed class ScryfallCardDto
{
    public Guid id { get; set; }
    public Guid oracle_id { get; set; }
    public List<int> multiverse_ids { get; set; }
    public int mtgo_id { get; set; }
    public int mtgo_foil_id { get; set; }
    public int tcgplayer_id { get; set; }
    public int cardmarket_id { get; set; }
    public string name { get; set; }
    public string lang { get; set; }
    public DateTime released_at { get; set; }
    public Uri uri { get; set; }
    public Uri scryfall_uri { get; set; }
    public string layout { get; set; }
    public bool highres_image { get; set; }
    public string image_status { get; set; }
    public ScryfallCardImageUrisLinks ScryfallCardImageUris { get; set; }
    public string mana_cost { get; set; }
    public double cmc { get; set; }
    public string type_line { get; set; }
    public string oracle_text { get; set; }
    public List<char> colors { get; set; }
    public List<char> color_identity { get; set; }
    public List<string> keywords { get; set; }
    public ScryfallCardLegalitiesDto legalities { get; set; }
    public List<string> games { get; set; }
    public bool reserved { get; set; }
    public bool foil { get; set; }
    public bool nonfoil { get; set; }
    public List<string> finishes { get; set; }
    public bool oversized { get; set; }
    public bool promo { get; set; }
    public bool reprint { get; set; }
    public bool variation { get; set; }
    // public Guid set_id { get; set; }
    public string set { get; set; }
    // public string set_name { get; set; }
    public string set_type { get; set; }
    // public Uri set_uri { get; set; }
    public Uri set_search_uri { get; set; }
    public Uri scryfall_set_uri { get; set; }
    public Uri rulings_uri { get; set; }
    public Uri prints_search_uri { get; set; }
    public string collector_number { get; set; }
    public bool digital { get; set; }
    public string rarity { get; set; }
    public string flavor_text { get; set; }
    public Guid card_back_id { get; set; }
    public string artist { get; set; }
    public List<Guid> artist_ids { get; set; }
    public Guid illustration_id { get; set; }
    public string border_color { get; set; }
    public string frame { get; set; }
    public bool full_art { get; set; }
    public bool textless { get; set; }
    public bool booster { get; set; }
    public bool story_spotlight { get; set; }
    public int edhrec_rank { get; set; }
}

public sealed class ScryfallCardImageUrisLinks
{
    public Uri small { get; set; }
    public Uri normal { get; set; }
    public Uri large { get; set; }
    public Uri png { get; set; }
    public Uri art_crop { get; set; }
    public Uri border_crop { get; set; }
}