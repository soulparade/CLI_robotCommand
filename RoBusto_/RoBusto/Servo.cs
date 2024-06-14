namespace RoBusto;

public class Servo(int AngMax, int AngMin, int AngAtt, int Pin)
{
    public int AngMax { get; set; } = AngMax;
    public int AngMin { get; set; } = AngMin;
    public int AngAtt { get; set; } = AngAtt;
    public int Pin { get; set; } = Pin;
    
    string siglaMotore = "JX Servo PDI-6225MG-300";
    string marca = "JX Servo";

    private int offset = 0;

    public int Modifica(int parametro, int valore)
    {
        parametro = valore;
        return parametro;
    }

    public void ApriMax()
    {
        AngAtt = AngMin;
    }

    public void ChiudiMin()
    {
        AngAtt = AngMax;
    }

    public void log(string nMano, string nDito, string nParametro, string data, string logfile)
    {
        using (StreamWriter sw = File.AppendText(logfile + ".txt"))
        {
            sw.WriteLine(nMano + ": " + nDito + ": " + nParametro + ": " + data);
        }
    }
}