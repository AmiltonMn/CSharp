using static NewSystem.NewConsole;

// ! Tipos

// * Inteiros


// byte bt = 0;
// short st = 0;
// int it = 0;
// long lg = 1;

// // * Flutuantes
// float f = 0.1f;
// double d = -.1;
// decimal dc = 0.2M; // ? Dinheiro 💵

// // * Caractere
// char c = 'a';
// string str = "Uma string";

// // * Boolean
// bool bl = false;

// // ! Fim dos tipos convencionais

// // * ------------------------------------

// // ! Tipos anuláveis

// int? podeSerNull = 1_000_000_000; // ? Talvez funciona nessa síntaxe aqui: int ? podeSerNull = null - Testar depois, fica mais clean code
// float? flt = (float)podeSerNull;

// // ! Comparando string

// string a = "a";
// string b = "b";

// if (a == b)
// {
//     a = "São iguais";
// } else {
//     a = "Não são iguais";
// }

// // ! Declarando array

// int[] arr = {1, 2, 3};

// // ! Tuplas

// var tuple = (name: "Irineu", idade: 20);

// // ! ----------------

// AlgumaClasse agc = new();
// Pessoa Irineu = new ("Irineu");

// Console.WriteLine("Hello, World!");

// var wow = "Esse aqui é um WOW";
// string s = "String";

// Console.WriteLine(a);
// Console.WriteLine(wow);
// Console.WriteLine(s);
// Console.WriteLine(arr);
// Console.WriteLine(tuple);

// Console.WriteLine(Irineu.Name);
// Console.WriteLine(Irineu.docs);

// foreach (var item in Irineu.docs)
// {
//     Console.WriteLine("Documento: " + item);
// }

// Classe cls = new();
// cls["Qtd Alunos"] = 12;
// cls["Professor"] = "Nycollas";

// Funcionario funcionario = new ("Jorge", 1_000.00M);

// Console.WriteLine(funcionario.Salario.ToString("C2"));

// Console.WriteLine(cls["Professor"]);
// Console.WriteLine("Hello, World 2!");

// ! O NewConsole foi importado, no início do código, usando o using static NewSystem.NewConsole, devido a isso, as funções dele podem ser chamadas sem o objeto na frente delas.

Print("Pressione uma tecla: ");
int ? a = ReadLineInt();
Print("Tecla numérica pressionada: " + a);

Print("Pressione outra tecla: ");
int ? b = ReadLineInt();
Print("Tecla numérica pressionada: " + b);

var space = Console.ReadLine();

Print(space);

if (a is null || b is null)
    Print("Algum número inválido!");
else
    Print("Soma dos números: " + (a + b));