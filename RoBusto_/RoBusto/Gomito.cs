namespace RoBusto;

public class Gomito : Servo
{
    public string Name { get; set; }
    public Gomito(int maxAngle, int minAngle, int actAngle, int pin, string name): base(maxAngle, minAngle, actAngle, pin)
    {
        Name = name;
    }
}