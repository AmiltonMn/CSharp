public class Battle()
{
    protected List<Machine> machinesList { get; set; }

    protected List<Machine> enemyMachinesList { get; set; }

    public void NewBattle(Game game, List<Machine> machines, List<Machine> enemyMachines)
    {
        machinesList = machines;
        enemyMachinesList = enemyMachines;

        foreach (var machine in machinesList)
            machine.BeginTurn(game);
        
        foreach (var machine in enemyMachinesList)
            machine.BeginTurn(game);

        while (true)
        {
            if (machinesList.Count == 0 || enemyMachinesList.Count == 0)
                break;

            var enemyMachine = enemyMachinesList[0];
            var playerMachine = machinesList[0];

            playerMachine.Hurt(enemyMachine.attack, game);
            enemyMachine.Hurt(playerMachine.attack, game);
            
            if (enemyMachine.life <= 0)
                enemyMachinesList.Remove(enemyMachine);
            
            if (playerMachine.life <= 0)
                machinesList.Remove(playerMachine);
        }
    }
}