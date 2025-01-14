namespace Database.Exceptions;

public class ConvertObjectException : Exception
{
    public override string Message => "Algum elemento do banco está mal formatado enão pode ser convertido!";
}