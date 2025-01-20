namespace DataBase;

public abstract class DatabaseObject
{
    internal protected abstract void LoadFrom(string[] data);
    internal protected abstract string[] SaveTo();
}