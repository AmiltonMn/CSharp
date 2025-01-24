// var b = new B<A1, A>(new A1());

// public record B<T, U>(T Value)
//     where T : U;

// public class A;

// public class A1 : A {}

// public class A2 : A {}

// public class A3 : A {}

// ? Restrições genéricas

// var b = new B<A1>();

/* 
    ? Aqui podemos utilizar as funções da classe A, pois, na restrição de herança, estamos passando o A.
    ? Como o A possui o Load, podemos utilizar ele.
*/
// public record B<T> 
//     where T : A, new()
// {
//     public T Create(int number, string message)
//     {
//         var obj = new T();
//         obj.Load(number, message);

//         return obj;
//     }
// };

// public abstract class A
// {
//     public int Value1 { get; set; }

//     public string Value2 { get; set; }

//     public void Load(int a, string b)
//     {
//         this.Value1 = a;
//         this.Value2 = b;
//     }
// };

// public class A1 : A {}

// public class A2 : A {}

// public class A3 : A {}


// ? Reflection

using System.Reflection;

var type = typeof(Funcionario);
Console.WriteLine($"Class: {type}");

foreach (var prop in type.GetProperties())
    Console.WriteLine($"\t{prop.Name} - {prop.PropertyType}");

foreach (var field in type.GetRuntimeFields())
    Console.WriteLine(field.Name);

var func = new Funcionario("Donzinho");
func.Idade = 14;

var nameProp = type.GetProperty("Nome");
nameProp.SetValue(func, "Queilinha");

Console.WriteLine($"Novo nome: {func.Nome}");

var project = Assembly.GetExecutingAssembly();
List<Controller> controllers = 
    project.GetTypes()
    .Where(t => t.BaseType == typeof(Controller))
    .Select(t =>
    {
        var obj = Activator.CreateInstance(t);
        if (obj is Controller controller)
            return controller;

        return null;
    })
    .ToList()!;

foreach (var controller in controllers)
{
    var controllerType = controller.GetType();
    var method = controllerType.GetMethod("Get");
    if (method is null)
        continue;
    
    method.Invoke(controller, []);
}

public abstract class Controller;
public class ShopController : Controller
{
    public void Get() {
        Console.WriteLine("Hello, World!");
    }
};

public class LoginController : Controller;

public class Funcionario(string nome)
{
    public string Nome { get; set; } = nome;
    public int Idade { get; set; }

    public void Trabalhar(int horas)
    {
        if (horas > 12)
            Console.WriteLine("Estou cansado chefe!");
    }
}