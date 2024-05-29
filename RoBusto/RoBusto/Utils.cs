namespace RoBusto;
using System.Text.Json;
public class Utils
{
    
    // spostare i file json nella cartella debug
    public static void SerializeAndSaveBraccio(Braccio braccio, string fileName)
    {
        string pathJson = Path.GetFullPath(fileName);
        File.WriteAllText(pathJson + ".json", JsonSerializer.Serialize(braccio));

    }
        
    public static Braccio DeserializeBraccio(string fileName)
    {
        string pathJson = Path.GetFullPath(fileName);
        string jsonStr = File.ReadAllText(pathJson + ".json");
        return JsonSerializer.Deserialize<Braccio>(jsonStr);
    }

}