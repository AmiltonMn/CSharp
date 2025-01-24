RAM memoria = new();
memoria.Marca = "Pichau";
memoria.GB = 8;
memoria.MHZ = 3200;
memoria.HasLED = false;

RAM memoria2 = new();
memoria2.Marca = "Pichau";
memoria2.GB = 8;
memoria2.MHZ = 3200;
memoria2.HasLED = false;

List<RAM> memorias = [memoria, memoria2];

Computador computador = new();
computador.CPU = "Ryzen 7 5700x";
computador.GPU = "RTX 4060";
computador.PlacaMae = "B450M";
computador.RAM = memorias;
computador.HD = 500;

Pessoa pessoa1 = new();
pessoa1.Name = "Amilton";
pessoa1.Idade = 20;
pessoa1.Notas = [10, 9, 4];
pessoa1.arr = ["aaa", "aaa", "aaa"];

pessoa1.PC = computador;

Console.WriteLine(pessoa1.ToJson());