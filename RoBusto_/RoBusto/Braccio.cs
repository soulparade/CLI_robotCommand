namespace RoBusto;


public class Braccio( string nome, Spalla spalla, Gomito gomito, Polso polso, Mano mano)
{
    public string Nome { get; init; } = nome; // name
    public Spalla Spalla { get; init; } = spalla; // shoulder
    public Gomito Gomito { get; init; } = gomito;// elbow
    public Polso Polso { get; init; } = polso;// wrist
    public Mano Mano { get; init; } = mano; // hand


}


