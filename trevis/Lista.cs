namespace MyLists;

public class Lista<T>
{

    public int size { get; set; } = 5;

    int count = 0;

    T[] array = new T[10];

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= size)
                throw new IndexOutOfRangeException();
            
            return array[index];
        }
        set
        {
            if (index < 0 || index >= size)
                throw new IndexOutOfRangeException();

            array[index] = value;
        }
    }

    #region Methods
    public void Add(T value)
    {
        
        ExpandIfNeeded();
        this.array[count] = value;
        count ++;
    }

    private void ExpandIfNeeded()
    {
        if (size >= count)
            return;

        Expand();
    }

    private void Expand()
    {
        size = size *2;
        T[] newArray = new T[size];

        Array.Copy(array, newArray, array.Length);
        this.array = newArray;
    }

    #endregion
}

public struct DateTime
{
    readonly long ticks = 0;

    public DateTime() {}
    public DateTime(long ticks)
        => this.ticks = ticks;

    public DateTime(int dayOfYear, int year)
    {
        int yearsPassed = year - 1970;
        int daysPassed = dayOfYear + yearsPassed * 365;
        ticks = daysPassed * 24 * 60 * 60 * 1000;
    }

    public static TimeSpan operator -(DateTime date, DateTime date2)
        => new TimeSpan(date.ticks - date2.ticks);

    public static DateTime operator +(DateTime date, TimeSpan duration)
        => new DateTime(date.ticks + duration.Ticks);

}

public struct TimeSpan
{
    long ticks = 0;

    public long Ticks => ticks;

    public TimeSpan(long ticks)
    {
        this.ticks = ticks;
    }

    public static TimeSpan operator +(TimeSpan duration1, TimeSpan duration2)
    {

    }

    internal static object FromHours(int hours)
        => new TimeSpan(hours * 60 * 60 * 1000);

    internal static object FromMinutes(int minutes)
        => new TimeSpan(minutes * 60 * 1000);

    internal static object FromSeconds(int seconds)
        => new TimeSpan(seconds * 1000);
}

public class Number
{
    double x;

    public static implicit operator Number(int value)
        => new Number() { x = value };
}