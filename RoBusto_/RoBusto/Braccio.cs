namespace RoBusto;


public class Braccio( string nome, Spalla spalla, Gomito gomito, Polso polso, Mano mano)
{
    public string Nome { get; init; } = nome; 
    public Spalla Spalla { get; init; } = spalla;
    public Gomito Gomito { get; init; } = gomito;
    public Polso Polso { get; init; } = polso;
    public Mano Mano { get; init; } = mano;


}


