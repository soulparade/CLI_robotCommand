using System.Runtime.InteropServices.Marshalling;

namespace RoBusto;
public class Mano(List<Dito> dita)
{
    public List<Dito> Dita { get; set; } = dita;
    
    
    public void ApriMano()
    {

        foreach( var dito in Dita )
        { 
            dito.ApriDito();
        }
    }

    public void ChiudiMano()
    {

        foreach ( var dito in Dita )
        { 
            dito.ChiudiDito();
        }
    }

    public void SegnoVittoria()
    {
        Dita[0].ChiudiMin();
        Dita[1].ApriMax();
        Dita[2].ApriMax();
        Dita[3].ChiudiMin();
        Dita[4].ChiudiMin();
        
    }

    public void PolliceInSu()
    {
        Dita[0].ApriMax();
        Dita[1].ChiudiMin();
        Dita[2].ChiudiMin();
        Dita[3].ChiudiMin(); 
        Dita[4].ChiudiMin();
    }
}