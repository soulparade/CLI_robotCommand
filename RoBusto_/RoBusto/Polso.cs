namespace RoBusto;

public class Polso : Servo
{
    public string Name { get; set; }
    public Polso(int AngMax, int AngMin, int AngAtt, int Pin, string name): base(AngMax, AngMin, AngAtt, Pin)
    {
        Name = name;
    }

    public int AngDritto = 120;
}