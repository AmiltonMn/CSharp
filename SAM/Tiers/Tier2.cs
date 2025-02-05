
public class Tier2 : Tier
{
    public override List<Machine> TierMachines => [new FuradeiraDeColuna(), new FornoIndustrialAGas(), new RetificaPlana()];

    private Tier2() { }

    private static Tier instance;

    public static Tier GetInstance()
    {
        if (instance is null)
            instance = new Tier2();
        
        return instance;
    }

    protected override int TierNumber { get; } = 2;
}