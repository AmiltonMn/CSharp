public abstract class Machine
{
    public int level { get; set; } = 1;

    public int exp { get; set; } = 1;

    public abstract int tier { get; set; }

    public abstract int life { get; set; }

    public abstract int attack { get; set; }

    public void UpExperience(Machine mergeMachine)
    {
        exp += mergeMachine.exp;

        life = mergeMachine.life > life ? mergeMachine.life + 1 : life + 1;
        attack = mergeMachine.attack > attack ? mergeMachine.attack + 1 : attack + 1;

        if (exp % 3 == 0)
            level ++;
    }
    public virtual void Sell(Game game) 
        => game.Gold += level;


    public virtual int Attack() 
        => attack;

    public virtual void Die(Game game)
        => game.Machines.Remove(this);

    public virtual void Hurt(int attack, Game game)
    {
        life -= attack;
    }
        
    public virtual void Buy(Game game) { }

    public virtual void BeginTurn(Game game) { }

    public virtual void EndTurn(Game game) { }

}