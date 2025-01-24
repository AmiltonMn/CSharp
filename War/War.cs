
using System.Reflection.Metadata.Ecma335;

public class War
{
    private static Random rand = new Random();

    public static int jogada()
        => rand.Next(6) + 1;

    static int Battle(List<int> attackRolls, List<int> defenseRolls)
    {
        int kills = 0;
        
        for (int i = (attackRolls.Count < defenseRolls.Count ? attackRolls.Count - 1 : defenseRolls.Count - 1); i >= 0; i--)
        {
            int result = (attackRolls[i], defenseRolls[i]) switch
            {
                (int x, int y) when x > y => 1,
                _ => 0
            };

            kills += result;
        }

        return kills;
    }

    public static int Wars(int battles, int attackers, int defensers)
    {
        int kills = 0;
        int count = 0;

        List<int> attackRolls = [];
        List<int> defenseRolls = [];

        for (int i = 0; i < battles; i++)
        {
            int attack = attackers;
            int defense = defensers;

            while (true)
            {
                if (attack <= 1 || defense <= 0)
                    break;

                for (int j = 0; j < (attack <= 4 ? attack - 1: 3); j++)
                    attackRolls.Add(jogada());

                for (int j = 0; j < (defense < 3 ? defense : 3); j++)
                    defenseRolls.Add(jogada());

                attackRolls.Sort();
                defenseRolls.Sort();

                kills = Battle(attackRolls, defenseRolls);

                defense -= kills;
                attack += kills -3;

                attackRolls.Clear();
                defenseRolls.Clear();
            }

            if (defense <= 0)
                count ++;
        }

        return count;
    }
}
