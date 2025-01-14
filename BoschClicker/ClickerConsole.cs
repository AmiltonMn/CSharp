namespace ClickerConsoleNameSpace;

public class ClickerConsole
{
    public static int ? ReadKeyInt() 
    {
        var str = Console.ReadKey();

        return (int)str.KeyChar;
    }
} 