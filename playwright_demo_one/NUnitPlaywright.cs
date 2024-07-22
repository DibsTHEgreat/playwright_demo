using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;


namespace PlaywrightDemoDiv;

public class NUnitPlaywright : PageTest
{
    private IBrowser browser;
    private IPage page;

    [SetUp]
    public async Task Setup()
    {
        var launchOptions = new BrowserTypeLaunchOptions
        {
            Headless = false
        };
        
        browser = await Playwright.Chromium.LaunchAsync(launchOptions);

        page = await browser.NewPageAsync();

        await page.GotoAsync("http://www.eaapp.somee.com");
    }

    [Test]
    public async Task Test1()
    {
        var lnkLogin = page.Locator(selector: "text=Login");

        await lnkLogin.ClickAsync();
        await page.ClickAsync(selector: "text=Login");
        await page.FillAsync(selector: "#UserName", value: "admin");          
        await page.FillAsync(selector: "#Password", value: "password");

        var btnLogin = page.Locator(selector: "input", new PageLocatorOptions { HasTextString = "Log in" });

        await btnLogin.ClickAsync();

       // await page.ClickAsync(selector: "text=Log in");

        await Expect(page.Locator(selector:"text='Employee Details'")).ToBeVisibleAsync();
    }

    [TearDown]
    public async Task Teardown()
    {
        if (browser != null)
        {
            await browser.CloseAsync();
        }
    }
}
