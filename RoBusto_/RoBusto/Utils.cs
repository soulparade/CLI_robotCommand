namespace RoBusto;
using System.Text.Json;

public class Utils
{
    public static void SerializeAndSaveBraccio(Braccio braccio, string fileName)
    {
        string pathJson = Path.GetFullPath(fileName);
        Console.WriteLine(pathJson);
        string text = JsonSerializer.Serialize(braccio);
        File.WriteAllText(pathJson + ".json", text);

    }
    public static Braccio DeserializeBraccio(string fileName)
    {
        
        string pathJson = Path.GetFullPath(fileName);
        string jsonStr = File.ReadAllText(pathJson + ".json");
        var options = new JsonSerializerOptions
        {
            IncludeFields = true
        };
        return JsonSerializer.Deserialize<Braccio>(jsonStr, options) !;
    }

}