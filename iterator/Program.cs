int[] array = [ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 ];
var result = array
    .Where(i => i % 2 == 0)
    .Select(i => i * i);

Console.WriteLine(result);

for (int i = 0; i < array.Count(); i++)
{
    result.MoveNext();

    Console.WriteLine(result.Current);
}

public static class Enumerator
{
    public static IEnumerator<R> Select<T, R>(
        this IEnumerable<T> source,
        Func<T, R> map
    )
    {
        var it = source.GetEnumerator();
        while (it.MoveNext())
            yield return map(it.Current);
    }

    public static IEnumerable<T> Where<T>(
        this IEnumerable<T> source,
        Func<T, bool> predicate
    )
    {
        var it = source.GetEnumerator();
        while (it.MoveNext())
            if (predicate(it.Current))
                yield return it.Current;
    }

    public static T? FirstOrDefault<T>(this IEnumerable<T> coll)
    {
        var it = coll.GetEnumerator();

        if(it.MoveNext())
            return it.Current;
        
        return default;
    }

    public static T? LastOrDefault<T>(this IEnumerable<T> coll)
    {
        var it = coll.GetEnumerator();
        var value = default(T);

        if (!it.MoveNext())
            return default;
        
        while (it.MoveNext())
            value = it.Current;

        return value;
    }

    public static T[] ToArray<T>(this IEnumerable<T> coll)
    {
        var it = coll.GetEnumerator();
        int count = 0;

        int size = coll.Count();
        
        T[] array = new T[size];

        while(it.MoveNext())
        {
            array[count] = it.Current;
            count ++;
        }

        return array;
    }

    public static List<T> ToList<T>(this IEnumerable<T> coll)
    {
        List<T> newList = new List<T>();
        var it = coll.GetEnumerator();

        while (it.MoveNext())
            newList.Add(it.Current);

        return newList;
    }

    public static IEnumerable<T> Take<T>(this IEnumerable<T> coll, int num)
    {
        var it = coll.GetEnumerator();

        for (int i = 0; i < num; i++)
        {
            if (it.MoveNext())
                yield return it.Current;
        }
    }

    public static IEnumerable<T> Skip<T>(this IEnumerable<T> coll, int num)
    {
        var it = coll.GetEnumerator();
        int count = coll.Count();

        for (int i = 0; i < count; i++)
        {
            it.MoveNext();

            if (i >= num)
                yield return it.Current;
        }
    }

    public static IEnumerable<T> Append<T>(this IEnumerable<T> coll, T item)
    {
        var it = coll.GetEnumerator();

        while (it.MoveNext())
            yield return it.Current;

        yield return item;
    }

    public static IEnumerable<T> Preprend<T>(this IEnumerable<T> coll, T item)
    {
        var it = coll.GetEnumerator();

        yield return item;

        while (it.MoveNext())
            yield return it.Current;
    }

    public static int Count<T>(this IEnumerable<T> coll)
    {
        int count = 0;
        var it = coll.GetEnumerator();

        while (it.MoveNext())
            count ++;

        return count;
    }

    // public static IEnumerable<int> PegaPar(this IEnumerable<int> coll)
    // {
    //     foreach (var val in coll)
    //         if (val % 2 == 0)
    //             yield return val;
    // }
    
    // public static IEnumerable<int> PegaQuadrado(this IEnumerable<int> coll)
    // {
    //     foreach (var x in coll)
    //         yield return x * x;
    // }

    // public static IEnumerable<int> PegaTop4(this IEnumerable<int> coll)
    // {
    //     var it = coll.GetEnumerator();
    //     for (int i = 0; i < 4; i++)
    //     {
    //         if (it.MoveNext())
    //             yield return it.Current;
    //     }
    // }
    
    // public static int Sum(this IEnumerable<int> array)
    // {
    //     int soma = 0;
    //     var it = array.GetEnumerator();
    //     while (it.MoveNext())
    //     {
    //         soma += it.Current;
    //     }
    //     return soma;
    // }
}

// public interface IEnumerable<T>
// {
//     IEnumerator<T> GetEnumerator();
// }

// public interface IEnumerator<T>
// {
//     bool MoveNext();
//     T Current { get; }
// }