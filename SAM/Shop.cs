public class Shop
{
    public List<Machine> Available { get; set; }

    public List<Machine> CurrentShop { get; set; }

    public Random random = new Random();

    public List<Tier> tiers { get; set; } = [Tier1.GetInstance(), Tier2.GetInstance()];

    public void UpdateShop(Game game)
    {
        game.Gold --;

        CurrentShop.Clear();

        for (int i = 0; i < 3 + ((game.Tier - 1) / 2); i++)
            CurrentShop.Add(Available[random.Next(0, Available.Count)]);
    }

    public void Buy(Game game, int MachineIndex)
    {

        var machine = CurrentShop[MachineIndex];
        game.Machines.Add(machine);

        machine.Buy(game);

        CurrentShop.Remove(machine);
    }

    public void AttMachines(Game game)
    {
        foreach (var tier in tiers)
            tier.AddToList(Available, game);
    }
}