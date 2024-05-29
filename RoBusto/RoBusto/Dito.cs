namespace RoBusto;

public class Dito : Servo // finger
{
    public string Name { get; set; }
    public Dito(int maxAngle, int minAngle, int actAngle, int pin, string name): base(maxAngle, minAngle, actAngle, pin)
    {
        Name = name;
    }

    //bool TrFl = false;
    //int SogliaSens = 0; useless things
    public void ApriDito()
    { 
        ApriMax();
    }
    public void ChiudiDito()
    {
        ChiudiMin();
    }

    /*public void SensoreTocco( double SogliaSens )    useless things
    {
        while (!TrFl)
        {
            AngAtt++; Console.WriteLine(" " + AngAtt );

            Console.WriteLine("Inserie valore sensore: "); 
            double sens = Convert.ToDouble(Console.ReadLine());

            if ( sens >= SogliaSens )
            { 
                Console.WriteLine("oggetto toccato"); TrFl = true;
            }
        }
    }*/
}