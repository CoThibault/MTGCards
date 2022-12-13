using System.Diagnostics;
using System.Net;
using MTGCards.dtos.Dtos;
using MTGCards.dtos.Dtos.Scryfall;
using Newtonsoft.Json;

namespace MTGCards.tests;

[TestFixture]
internal sealed class DeserializationTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Deserialize_from_MTGJson()
    {
        //Arrange
        var setsDirectory = new DirectoryInfo(@"C:\Users\Thibault\Desktop\TMP\AllSetFiles");
        var sets = new Dictionary<string, MTGJsonSetDto>();
        
        //Act
        foreach (var setFile in setsDirectory.GetFiles())
        {
            var res = JsonConvert.DeserializeObject<MTGJsonSetDto>(File.ReadAllText(setFile.FullName));
            sets.Add(res.data.name, res);
        }
        
        //Assert
        Assert.IsNotEmpty(sets);
    }

    [Test]
    public void Deserialize_from_Scryfall_card()
    {
        //Arrange
        var file = new FileInfo(@"C:\Users\Thibault\Desktop\TMP\MTG\scryfall\cardObjectExample.json");
        
        //Act
        var res = JsonConvert.DeserializeObject<ScryfallCardDto>(File.ReadAllText(file.FullName));

        //Assert
        Assert.IsNotNull(res);
    }

    [Test]
    public void Deserialize_from_Scryfall_multiple_cards()
    {
        //Arrange
        var file = new FileInfo(@"C:\Users\Thibault\Desktop\TMP\MTG\scryfall\cardObjectMultiExample.json");
        
        //Act
        var res = JsonConvert.DeserializeObject<List<ScryfallCardDto>>(File.ReadAllText(file.FullName));

        //Assert
        Assert.IsNotNull(res);
    }

    [Test]
    public void Deserialize_from_Scryfall_all_cards()
    {
        //Arrange
        var file = new FileInfo(@"C:\Users\Thibault\Desktop\TMP\MTG\scryfall\all-cards-20221023091446.json");
        var watch = new Stopwatch();
        var cards = new List<ScryfallCardDto>();
        //Act
        watch.Start();

        using (var client = new WebClient())
        using (var stream = client.OpenRead(file.FullName))
        using (var reader = new StreamReader(stream))
        using (var jsonReader = new JsonTextReader(reader))
        {
            jsonReader.SupportMultipleContent = true;
            var serializer = new JsonSerializer();
            while (jsonReader.Read())
            {
                if (jsonReader.TokenType == JsonToken.StartObject)
                {
                    cards.Add(serializer.Deserialize<ScryfallCardDto>(jsonReader));
                }
            }
        }
        
        var timeSpent = watch.ElapsedMilliseconds;

        //Assert
        Assert.IsNotEmpty(cards);
    }
}