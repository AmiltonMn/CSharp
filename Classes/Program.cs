Console.WriteLine("Hello, World!");

var aluno = new Aluno("Donzinho", 16);
var aluno2 = aluno with { idade = 40 };

var box = new Caixa("Caixa do Don", 8);
box.Valor = 30;

box.OnValueChanged += (valor, box) => Console.WriteLine($"A {box.Nome} tem valor de: {box.Valor}");

public class CaixaValueChangedEventArgs : EventArgs
{
    public int Valor { get; set; }
}

public class Caixa(string nome, int valor)
{
    // O Action<int> recebe um valor, pois o parâmetro "int" está dentro de "<>"
    public Action<int, Caixa> OnValueChanged;


    public string Nome { get; set; } = nome;

    private int valor = valor;
    public int Valor
    {
        get => valor;
        set
        {
            valor = value;
            if (OnValueChanged is null)
                return;

            OnValueChanged(8, this);
        }
    }
}

public class MyExpection(int code) : Exception
{
    public int Code => code;
    public override string Message => "Deu uns erro ai fi;";
};


public class Pessoa(string nome)
{
    // Métodos (method)
    public void Falar() {}

    public void Envelhecer()
    {
        Idade ++;
    }

    // Campos (Field)
    private readonly string nome;

    // Propriedades (Properties)
    public string Nome => nome;

    public required int Idade { get; set;}

    // Outras classes (records, enums, ...)
    // Construtores
    // Destrutores
    // Sobrecarga de operadores
    // Eventos
}

// try
// {
//     throw new MyExpection(500);
// }
// catch (MyExpection ex) when (ex.Code == 500)
// {
//     throw;
//     throw ex;
// }
// catch (Exception ex)
// {

// }
// finally
// {

// };

public record Aluno(string nome, int idade);