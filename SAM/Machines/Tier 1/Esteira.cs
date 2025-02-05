public class Esteira : Machine
{
    protected override int tier { get; set; } = 1;
    protected override int life { get; set; } = 3;
    protected override int attack { get; set; } = 1;

    public override void Sell(Game game)
    {
        game.Gold += level + 1;
    }
}