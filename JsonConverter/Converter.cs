using System.Collections;
using System.Text;

public static class Converter
{
    public static string ToJson<T>(this T obj)
    {
        var sb = new StringBuilder();
        toJson(obj, sb, 0);
        return sb.ToString();

    }

    private static void toJson<T> (T obj, StringBuilder sb, int tabs)
    {
        sb.Append($"{new string('\t', tabs)}{{\n");

        var objectType = obj.GetType();

        foreach (var item in objectType.GetProperties())
        {
            sb.Append($"{new string('\t', tabs + 1)}\"{item.Name}\": ");

            var objeto = item.GetValue(obj);
            if (objeto is IEnumerable list && objeto is not string)
            {
                sb.Append($"[\n{new string('\t', tabs + 2)}");

                foreach (var value in list)
                {
                    if (value is string)
                    {
                        sb.Append($"\"{value}\", ");
                    }
                    else if (value.GetType().IsClass)
                    {
                        toJson(value, sb, tabs + 1);
                    }
                    else
                    {
                        sb.Append($"{value}, ");
                    }
                }

                sb.Remove(sb.Length - 2, 2);

                sb.Append($"\n{new string('\t', tabs + 1)}], \n");

            } 
            else if (item.GetValue(obj).GetType().IsClass && item.GetValue(obj) is not string) 
            {
                toJson(item.GetValue(obj), sb, tabs + 1);
                sb.Append($"\n{new string('\t', tabs)}}}\n");

            } else {
                if (item.GetValue(obj) is string)
                {
                    sb.Append($"\"{item.GetValue(obj)}\", \n");
                } else {
                    sb.Append($"{item.GetValue(obj)}, \n");
                }
            }
        }
        sb.Remove(sb.Length - 3, 3);

        sb.Append($"\n{new string('\t', tabs)}}}\n");
    }
}