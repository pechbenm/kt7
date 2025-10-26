public interface IConverter<T, U>
{
    U Convert(T value);
}

public delegate U ConverterDelegate<T, U>(T value);
   

public class StringToIntConverter : IConverter<string, int>
{
    public int Convert(string value)
    {
        return int.Parse(value);
    }
}

public class ObjectToStringConverter : IConverter<object, string>
{
    public string Convert(object value)
    {
        return value.ToString();
    }
    

}

class Program
{
    public static U[] ConvertArray<T, U>(T[] values, ConverterDelegate<T, U> converter)
    {
        U[] results = new U[values.Length];
        for (int i = 0; i < values.Length; i++)
        {
            results[i] = converter(values[i]);
        }
        return results;
    }
    static void Main()
    {

        StringToIntConverter stringToIntConverter = new StringToIntConverter();
        ConverterDelegate<string, int> stringToIntDelegate = stringToIntConverter.Convert;

        string[] stringValues = { "1", "2", "3" };
        int[] intValues = ConvertArray(stringValues, stringToIntDelegate);

        foreach (var value in intValues)
        {
            Console.WriteLine(value); 
        }


        ObjectToStringConverter objectToStringConverter = new ObjectToStringConverter();
        ConverterDelegate<object, string> objectToStringDelegate = objectToStringConverter.Convert;

        object[] objectValues = { 1, "Hello", true };
        string[] stringResults = ConvertArray(objectValues, objectToStringDelegate);

        foreach (var result in stringResults)
        {
            Console.WriteLine(result); 
        }
    }
}
