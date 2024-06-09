namespace SpeedBoot.DynamicTemplates.RazorEngine.Tests;

[TestClass]
public class TemplateProviderTest : TestBase
{
    private static string _templateFile = Path.Combine("Templates", "EmailTemplate.cshtml");
    private static string _templateContent = File.ReadAllText(_templateFile);

    [TestMethod]
    public void Test()
    {
        var provider = App.Instance.GetRequiredSingletonService<ITemplateProvider>();
        provider.Set(new Template(nameof(UserInfo), _templateContent));
        var userInfo = new UserInfo()
        {
            Name = "SpeedBoot"
        };
        Assert.IsTrue(provider.TryGet(nameof(UserInfo), userInfo,out var content));
        Assert.AreEqual("Welcome SpeedBoot", content);
    }
}
