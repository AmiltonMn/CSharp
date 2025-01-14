namespace Game;

public static class Clicker
{
    public static long ClickValue { get; set; } = 1;

    public static long Money { get; set; } = 0;

    public static long Screws { get; set; } = 0;

    public static long ScrewValue { get; set; } = 1;

    public static int ? ClickerKey { get; set; }

    public static double SPS { get; set; }

    public static long Multiplier { get; set; }

    public static long Click(long screws)
    {
        return screws + ClickValue;
    }

    public static long SellScrews()
    {
        Money += Screws * ScrewValue;

        Screws = 0;

        return Money;
    }
}