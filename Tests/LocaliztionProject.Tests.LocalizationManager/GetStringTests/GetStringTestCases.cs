using System.Globalization;

namespace LocaliztionProject.Tests.LocalizationManager.GetStringTests;

public class GetStringTestCases
{
    public static string JsonPath =
        "C:\\MyProjects\\LocalizationProject\\Tests\\LocaliztionProject.Tests.LocalizationManager\\GetStringTests\\Data.json";
    
    public static IDictionary<string, string> Dictionary = new Dictionary<string, string>
    {
        { "ru-RU.hello", "Привет" }, {"ru-RU.bye", "Пока"}
    };

    public static List<TestCaseItem> GetSuccess = new List<TestCaseItem>
    {
        new TestCaseItem("hello", null, "Привет"),
        new TestCaseItem("bye", new CultureInfo("ru-RU"), "Пока"),
        new TestCaseItem("hello", new CultureInfo("en-EN"), "Hello"),
        new TestCaseItem("bye", new CultureInfo("en-EN"), "Bye")
    };

    public static List<TestCaseItem> GetException = new List<TestCaseItem>
    {
        new TestCaseItem("nocode", null),
        new TestCaseItem("somecode", new CultureInfo("ru-RU")),
        new TestCaseItem("somecode", new CultureInfo("en-EN"))
    };
}

public class TestCaseItem
{
    public TestCaseItem(string code, CultureInfo cultureInfoName, string? expectedResult = null)
    {
        Code = code;
        CultureInfoName = cultureInfoName;
        ExpectedResult = expectedResult;
    }

    public string Code { get; set; }
    public CultureInfo CultureInfoName { get; set; }
    public string? ExpectedResult { get; set; }
}