public class Tier1 : Tier
{
    public override List<Machine> TierMachines { get; } = [new Martelo(), new Esteira(), new ChaveDeFenda()];
    
    private Tier1() { }

    private static Tier instance;

    public static Tier GetInstance()
    {
        if (instance is null)
            instance = new Tier1();
        
        return instance;
    }

    protected override int TierNumber { get; } = 1;
}