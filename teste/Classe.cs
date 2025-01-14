using System.Collections.Generic;

public class Classe
{
    private Dictionary<string, object> values = new();

    public object this[string properties]
    {
        get => values.ContainsKey(properties) ? values[properties] : null;
        set => values[properties] = value!;
    }
}