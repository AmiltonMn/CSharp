using DataBase;

namespace models;

public interface Irepository<T>
    where T : DatabaseObject
{
    List<T> All { get; }

    void Add(T obj);
}