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


}