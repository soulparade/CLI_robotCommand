namespace RoBusto;

public class Servo(int angMax, int angMin, int angAtt, int pin)
{
    public int AngMax { get; set; } = angMax;
    public int AngMin { get; set; } = angMin;
    public int AngAtt { get; set; } = angAtt;
    public int Pin { get; set; } = pin;
    
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