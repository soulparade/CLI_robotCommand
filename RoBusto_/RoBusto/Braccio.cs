using System.Runtime.Intrinsics.Arm;

namespace RoBusto;


public class Braccio( string nome, Spalla spalla, Gomito gomito, Polso polso, Mano mano)
{
    public string Nome { get; set; } = nome; // name
    public Spalla spalla { get; set; } = spalla; // shoulder
    public Gomito gomito { get; set; } = gomito;// elbow
    public Polso polso { get; set; } = polso;// wrist
    public Mano Mano { get; set; } = mano; // hand
}

