int battles = 10_000_00;

Random rand = new Random();

while (true)
{
    int count = War.Wars(battles, 1700, 1000);

    Console.WriteLine($"{((count * 100) / (float)battles)}%");

    // if ((count * 100) / (float)battles < 90)
    //     break;
}
