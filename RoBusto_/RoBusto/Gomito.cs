namespace RoBusto;

public class Gomito : Servo
{
    public string Name { get; set; }
    public Gomito(int AngMax, int AngMin, int AngAtt, int Pin, string name): base(AngMax, AngMin, AngAtt, Pin)
    {
        Name = name;
    }
}