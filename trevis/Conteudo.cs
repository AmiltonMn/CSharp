using System;
using MyLists;

// var i = 20;
// bool b = true;
// float f = 0;
// double d = 0;
// decimal m = 0; // ? Interrassante para guardar dinheiro
// object? o = null;

// Variável dinâmica (Horrenda, mas interessante)
// dynamic x = 312;
// x = "aasdass";

// char c = '3';
// string s2 = "";

// ulong ul = 123213213123; // Não aceita números negativos

// short daf = 3434; // 16 bits

// sbyte ssd = -32; // Byte com sinal

// var s = 200;
// var l = 0;

// Exemplo de um Delegate já pronto
// ! programação funcional será algo muito trabalhado no curso de C#

Func<int> func =  meDaODois;
int valor = func();

// * Arrow Function a lá Javascript
Func<int> func2 = () => 2;
int valor2 = func2();

// * recebe 2 ints como parâmetro e retorna um int como parametro
Func<int, int, int> func3 = (a, b) => a + b;
int valor3 = func3(3, 4);

int meDaODois() => 2;

var valorRecord = new Int1024(243, 23);
var valorRecord2 = valorRecord.Valor2;

WriteLine("Hello, World!");

var newPessoa = new Pessoa("Mauricio");

Lista<int> minhaLista = new Lista<int>();

minhaLista.Add(10);

for (int i = 0; i < 10; i++)
{
    minhaLista.Add(i);
    Console.WriteLine(minhaLista.size);
}

public struct Int256
{
    // Faz algo aqui
}

// Para herdar, utilizamos o ":"
public class Pessoa(string nome) : ISemIdeia
{
    int idade = 0;
    public string Nome { get; set; } = nome;
    public int Idade
    {
        get => idade;
        set => idade = value;
    }

    public void MeuMetodo()
        => System.Console.WriteLine("Hello, World!");

    public object this[int index]
    {
        get
        {
            return 2;
        }
        set
        {

        }
    }
    public void MeuOutroMetodo()
    {
        throw new NotImplementedException();
    }
}

public record Int1024(int Valor1, int Valor2);

public enum VaiChove
{
    Vai, Naosei, TasecoOTempo = 0x000, Talvez = 0b0000_1101
}

public interface ISemIdeia
{
    void MeuMetodo();
    void MeuOutroMetodo();
}

public delegate R MeuDelegado<R>();