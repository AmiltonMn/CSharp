public class Game
{
    private static Game? = null;

    public static Game current
        => Game ??= new Game();

    private Game() { }

    public static void Reset()
        => Game = null;

    public int level { get; set; }
    public Character main  { get; set;}
}