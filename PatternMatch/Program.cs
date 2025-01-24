int num = 450;

if (num is < 500 and > 400 and int number)
{
    Console.WriteLine(number);
}

List<int> list = [ 1, 2, 3, 4, 5 ];
int[] list2 = [ 0, ..list, 6, 7, 8 ];
foreach (var item in list2[2..5])
    Console.WriteLine(item); // 3, 4, 5

Console.WriteLine(list2[^1]); // 8
Console.WriteLine(list2[^3]); // 6


if ("Olá mundo" is [ .., 'm', 'u', 'n', 'd', 'o'])
{
    Console.WriteLine("Tem mundo");
}

int var1 = 3;
string var2 = "ACCEPTED";
bool var3 = false;

// Retornando valores diferentes de acordo com os valores que foram passados como parâmetros
int result = (var1, var2, var3) switch
{
    (0, "ACCEPTED", true) => 1,
    (>0, "ACCEPTED", false) => 2,
    (>5 and <18, "ACCEPTED" or "FAIL", true) => 3,
    (>18, _, false) => 4,
    _ => 5
};

List<int> values = [ 1, 2, 3, 4, 5, 6 ];
var result2 = values switch
{
    [ 1, 2, _, 4, ..] or [ .., 5, 6] => "OK",
    [ 1, 2, int value ] => value.ToString(), 
    _ => "VISH"
};

if (values is null)
    return;

// Aqui só podemos utilizar a variável "num3" quando esse IF for false
if (values is not [ 1, int num3, ..])
    return;
else
    Console.WriteLine(num3);

int valor = 1231;
int outrovalor = valor switch // Esse querido te avise se você não cobrir todos os possíveis resultados
{
    <1231 => 3,
    1231 => 4
};

List<Instrutor> instrutores = [ 
    new Instrutor("Don", 1.4f),
    new Instrutor("Queila", 1.45f),
    new Instrutor("Trevis", 2.45f) 
];

// Utilização do PatternMatching para poder retornar resultados diferentes
foreach (var instrutor in instrutores)
{
    string result4 = instrutor switch
    {
        { Altura: < 1.7f } => "Baixin KKKKK",
        { Altura: > 1.7f, Nome: not "Trevis" } => "Altin",
        _ => "Lindão"
    };

    Console.WriteLine($"{instrutor.Nome} é {result4}");
}

// Coalisão nula
var ETSCuritiba = new ETS("Curitiba", instrutores);
foreach (var instrutor in ETSCuritiba?.Instrutores ?? []) // Aqui na parte "ETSCuritiba?" caso a expressão da esquerda seja nul,a returna nulo, caso "ETSCuritiba.Instrutores" seja nulo, retorna "[]"
{
    Console.WriteLine($"{instrutor?.Nome ?? "Sem Nome"}"); // Aqui tem a mesma lógica, caso "instrutor" seja nulo, retorna um nulo, caso isso retorne nulo, retorna "Sem Nome"
}

public record ETS(string Cidade, List<Instrutor> Instrutores);

public record Instrutor(string Nome, float Altura);