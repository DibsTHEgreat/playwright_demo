using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace MyVersion
{
    [Parallelizable(ParallelScope.Self)]
    public class UnitTest2 : PageTest
    {
        [SetUp]
        public async Task Setup()
        {
            await Page.GotoAsync("http://eaapp.somee.com/");
        }

        [Test]
        [TestCaseSource(nameof(Login))]
        public async Task Test1(LoginModel login)
        {
            await Page.GetByRole(AriaRole.Link, new() { Name = "Login" }).ClickAsync();

            await Page.GetByLabel("UserName").ClickAsync();

            await Page.GetByLabel("UserName").FillAsync(login.Username);

            await Page.GetByLabel("Password").ClickAsync();

            await Page.GetByLabel("Password").FillAsync(login.Password);

            await Page.GetByRole(AriaRole.Button, new() { Name = "Log in" }).ClickAsync();

            await Page.GetByRole(AriaRole.Link, new() { Name = "Employee List" }).ClickAsync();

            await Expect(Page.GetByRole(AriaRole.Link, new() { Name = "Create New" })).ToBeVisibleAsync();
        }

        public static IEnumerable<LoginModel> Login()
        {
            yield return new LoginModel()
            {
                Username = "admin",
                Password = "password"
            };
        }
    }
}