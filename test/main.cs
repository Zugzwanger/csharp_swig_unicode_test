
class EncodingTest
{
    public static readonly string[] test_strings = {
        "JP: 戦争と平和", "RU: Война и мир", "EN: War and Peace"
    };


    static void Main(string[] args)
    {
        foreach (string expected in test_strings)
        {
            string result = csharp_api.copy_wstring(expected);

            if (result != expected)
            {
                System.Console.Write("[FAILED] '" + result + "' != '" + expected + "'");
            }
            else
            {
                System.Console.Write("[SUCCEED] '" + result + "'");
            }
            System.Console.WriteLine();
        }
    }
}
