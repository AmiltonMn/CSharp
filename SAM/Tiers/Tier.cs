public abstract class Tier
{
    public abstract List<Machine> TierMachines { get; }

    protected abstract int TierNumber { get; }

    public void AddToList(List<Machine> CrrList, Game game)
    {
        if (game.Tier < TierNumber )
            return;

        CrrList.AddRange(TierMachines);
    }   
}