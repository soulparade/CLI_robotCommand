using System.Text.Json.Serialization;
using System.Text.Json;

namespace RoBusto;

public class Dito : Servo 
{
    public string Name { get; set; }
    public Dito(int AngMax, int AngMin, int AngAtt, int Pin, string name): base(AngMax, AngMin, AngAtt, Pin)
    {
        Name = name;
    }
    
    public void ApriDito()
    { 
        ApriMax();
    }
    public void ChiudiDito()
    {
        ChiudiMin();
    }
    
}