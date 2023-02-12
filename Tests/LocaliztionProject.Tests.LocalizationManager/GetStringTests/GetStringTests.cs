using LocalizationProject.BL.Sources;

namespace LocaliztionProject.Tests.LocalizationManager.GetStringTests;

public class GetStringTests
{
    private LocalizationProject.BL.Managers.LocalizationManager _manager;
    
    [SetUp]
    public void Setup()
    {
        var sourceInMemory = new InMemorySource(GetStringTestCases.Dictionary);
        var sourceJson = new JsonSource(GetStringTestCases.JsonPath);
        
        _manager = new LocalizationProject.BL.Managers.LocalizationManager();
        _manager.RegisterSource(sourceInMemory);
        _manager.RegisterSource(sourceJson);
    }

    [Test]
    [TestCaseSource(typeof(GetStringTestCases), nameof(GetStringTestCases.GetSuccess))]
    public void ThenValidData_ReturnString(TestCaseItem testCase)
    {
        var result = _manager.GetString(testCase.Code, testCase.CultureInfoName);

        StringAssert.AreEqualIgnoringCase(testCase.ExpectedResult, result.Result);
    }
    
    [Test]
    [TestCaseSource(typeof(GetStringTestCases), nameof(GetStringTestCases.GetException))]
    public void ThenNotValidData_ThrowException(TestCaseItem testCase)
    {
        AsyncTestDelegate @delegate = async () => await _manager.GetString(testCase.Code, testCase.CultureInfoName);

        var exception = Assert.ThrowsAsync<Exception>(@delegate);
        StringAssert.AreEqualIgnoringCase("Не удалось найти локализацию строки!", exception?.Message);
    }
}