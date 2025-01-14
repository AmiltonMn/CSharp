namespace Database.Exceptions;

public class CustomNotDefinedException : Exception
{
    public override string Message => "O arquivo custom não foi definido.\nUse DB<T>SetCustom para definir o seu custom";
}