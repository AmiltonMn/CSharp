public class FornoIndustrialAGas : Machine
{
    protected override int tier { get; set; } = 2;
    protected override int life { get; set; } = 1;
    protected override int attack { get; set; } = 3;

    public override void BeginTurn(Game game)
        => game.Gold ++;
        
}