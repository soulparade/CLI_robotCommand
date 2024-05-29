namespace RoBusto;

public class Polso : Servo
{
    public string Name { get; set; }
    public Polso(int maxAngle, int minAngle, int actAngle, int pin, string name): base(maxAngle, minAngle, actAngle, pin)
    {
        Name = name;
    }
}