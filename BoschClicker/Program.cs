using ClickerConsoleNameSpace;
using static Game.Clicker;

long money = Money;

Console.WriteLine("Aperte a tecla para configurar seu \"clique\"");
int ? ClickerKey = ClickerConsole.ReadKeyInt();

Console.WriteLine("A tecla que foi pressionada: " + ClickerKey);

Machine machine1 = new Machine("Screw Maker ⚙️", "Generate 1 screw per second", 50);
Machine machine2 = new Machine("Screw Refinary 🏭", "Multiply your SPS by 1.1x", 100);
Machine machine3 = new Machine("Screw Packer 🤖", "Multiply your SPS by 1.5x", 200);

Upgrade upgrade1 = new Upgrade("Employee 👷‍♂️", "Give +1 to your click power", 100);
Upgrade upgrade2 = new Upgrade("Branch 🏢", "Give +10 to your click power", 1000);
Upgrade upgrade3 = new Upgrade("International Branch 🌍", "Give +50 to your click power", 10000);
Upgrade upgrade4 = new Upgrade("Screw Seller Employee 👨‍💼", "Sell your screws every 10s", 150);

bool shop =  false;
bool upgradeShop = false;
int buyResult = 0;

List<Machine> machines = [machine1, machine2, machine3];
List<Upgrade> upgrades = [upgrade1, upgrade2, upgrade3, upgrade4];

void Loop()
{
    int count = 0, countSell = 0;

    while (true)
    {
        if (!shop && !upgradeShop)
        {
            Console.Clear();

            Console.WriteLine($"Screws 🔩 : {Screws}");
            Console.WriteLine($"Money 💵 : {Money.ToString("C2")}");
            Console.WriteLine($"Click Power 👇 : {ClickValue}");
            Console.WriteLine($"SPS ⏱️ : {SPS}");
            Console.WriteLine("Press ENTER to go to the shop");
            Console.WriteLine("Press S to sell your screws!");
            Console.WriteLine("Press U to go to Upgrade Shop");

        } else if (shop && !upgradeShop) {

            Console.Clear();

            Console.WriteLine("Press BACKSPACE to go to the click area");

            Console.WriteLine();

            Console.WriteLine($"Screws 🔩 : {Screws}");
            Console.WriteLine($"Money 💵 : {Money.ToString("C2")}");

            Console.WriteLine("___________________________________");

            Console.WriteLine();

            Console.WriteLine("             Machines");

            Console.WriteLine("___________________________________");

            Console.WriteLine();

            for(int i = 0; i < machines.Count(); i++)
            {
                Console.WriteLine($"Press {i + 1} to buy this machine");
                Console.WriteLine($"Name: {machines[i].Name}");
                Console.WriteLine($"Description: {machines[i].Description}");
                Console.WriteLine($"Value: {machines[i].Value.ToString("C1")}");
                Console.WriteLine($"You have: {machines[i].Acquired}");   
                Console.WriteLine("___________________________________");
                Console.WriteLine();
            }

            switch (buyResult)
            {
                case 0:
                    break;
                
                case 1:
                    Console.WriteLine("\nYou don't have money to buy this machine!");
                    break;

                case 2:
                    Console.WriteLine("\nNew machine acquired!");
                    break;

                case 3:
                    Console.WriteLine("\nLeaving the shop...!");
                    break;
                
                default:
                    break;
            }

            buyResult = 0;

            Thread.Sleep(1000);

            count += 50;
            countSell += 50;

        } else if (upgradeShop && !shop) {
            
            Console.Clear();

            Console.WriteLine("Press BACKSPACE to go to the click area");

            Console.WriteLine();

            Console.WriteLine($"Screws 🔩 : {Screws}");
            Console.WriteLine($"Money 💵 : {Money.ToString("C2")}");

            Console.WriteLine("___________________________________");

            Console.WriteLine();

            Console.WriteLine("             Upgrades");

            Console.WriteLine("___________________________________");

            Console.WriteLine();

            for(int i = 0; i < upgrades.Count(); i++)
            {
                Console.WriteLine($"Press {i + 1} to buy this upgrade");
                Console.WriteLine($"Name: {upgrades[i].Name}");
                Console.WriteLine($"Description: {upgrades[i].Description}");
                Console.WriteLine($"Value: {upgrades[i].Value.ToString("C1")}");
                Console.WriteLine($"You have: {upgrades[i].Acquired}");   
                Console.WriteLine("___________________________________");
                Console.WriteLine();
            }

            switch (buyResult)
            {
                case 0:
                    break;
                
                case 1:
                    Console.WriteLine("\nYou don't have money to buy this upgrade!");
                    break;

                case 2:
                    Console.WriteLine("\nNew upgrade acquired!");
                    break;

                case 3:
                    Console.WriteLine("\nLeaving the shop...!");
                    break;

                case 4:
                    Console.WriteLine("\nYou already have this upgrade...!");
                    break;
                
                default:
                    break;
            }

            buyResult = 0;

            Thread.Sleep(1000);

            count += 50;
            countSell += 50;
        }

        if (!shop || !upgradeShop)
        {
            Thread.Sleep(20);
            count ++;
            countSell ++;
        }

        if (count >= 50)
        {
            Screws += (long)SPS;

            count = 0;
        }

        if (countSell >= 500 && upgrade4.Acquired)
        {
            SellScrews();

            countSell = 0;
        }
    }
}

Thread RT = new Thread(Loop);
RT.Start();


while (true)
{
    int ? key = ClickerConsole.ReadKeyInt();

    if (key == ClickerKey)
        Screws = Click(Screws);

    else if (key == 115)
        Money = SellScrews();

    else if (key == 13) {

        shop = true;

        while (shop)
        {
            key = ClickerConsole.ReadKeyInt();

            buyResult = 0;
    
            switch (key)
            {
                case 49:
                    if (Money < machine1.Value)
                    {
                        buyResult = 1;
                    } else {
                        machine1.Acquired += 1;
                        Money -= (long)machine1.Value;
                        machine1.Value *= 1.5f;
                        buyResult = 2;
                        SPS += 1;
                    }
                    break;

                case 50:
                    if (Money < machine2.Value)
                    {
                        buyResult = 1;
                    } else {
                        buyResult = 2;
                        machine2.Acquired += 1;
                        Money -= (long)machine2.Value;
                        machine2.Value *= 1.5f;
                        SPS *= 1.1;
                    }

                    break;

                case 51:
                    if (Money < machine3.Value)
                    {
                        buyResult = 1;
                    } else {
                        buyResult = 2;
                        machine3.Acquired += 1;
                        Money -= (long)machine3.Value;
                        machine3.Value *= 1.5f;
                        SPS *= 1.5;
                    }
                    break;

                case 8:
                    buyResult = 3;
                    shop = false;
                    break;
            }
        }

    } else if (key == 117) {

        upgradeShop = true;

        while (upgradeShop)
        {
            key = ClickerConsole.ReadKeyInt();

            buyResult = 0;
    
            switch (key)
            {
                case 49:
                    if (Money < upgrade1.Value)
                    {
                        buyResult = 1;
                    } else if (upgrade1.Acquired == true) {
                        buyResult = 4;
                    } else {
                        upgrade1.Acquired = true;
                        Money -= (long)upgrade1.Value;
                        ClickValue += 1;
                        buyResult = 2;
                    }

                    break;

                case 50:
                    if (Money < upgrade2.Value)
                    {
                        buyResult = 1;
                    } else if (upgrade2.Acquired == true) {
                        buyResult = 4;
                    } else {
                        buyResult = 2;
                        upgrade2.Acquired = true;
                        Money -= (long)upgrade2.Value;
                        ClickValue += 10;
                    }

                    break;

                case 51:
                    if (Money < upgrade3.Value)
                    {
                        buyResult = 1;
                    } else if (upgrade3.Acquired == true) {
                        buyResult = 4;
                    } else {
                        buyResult = 2;
                        upgrade3.Acquired = true;
                        Money -= (long)upgrade3.Value;
                        ClickValue += 50;
                    }
                    break;

                case 52:
                    if (Money < upgrade4.Value)
                    {
                        buyResult = 1;
                    } else if (upgrade4.Acquired == true) {
                        buyResult = 4;
                    } else {
                        buyResult = 2;
                        upgrade4.Acquired = true;
                        Money -= (long)upgrade4.Value;
                    }
                    break;

                case 8:
                    buyResult = 3;
                    upgradeShop = false;
                    break;
            }
        }
    }
}