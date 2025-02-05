public class Game
{
    public int Gold { get; set; } = 10;

    public int Tier { get; set; } = 1;

    public int Round { get; set;} = 0;

    public int Trophies { get; set; } = 0;

    public int Lifes { get; set; } = 5;

    public List<Machine> Machines { get; set; } = null;
 
}