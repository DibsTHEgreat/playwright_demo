using Microsoft.Playwright;

namespace PlaywrightDemo.Pages
{
    internal class LoginPageUpgraded
    {
        private IPage _page;
        public LoginPageUpgraded(IPage page) => _page = page;
        private ILocator _lnkLogin => _page.Locator(selector: "text=Login");
        private ILocator _txtUserName => _page.Locator(selector: "#UserName");
        private ILocator _txtPassword => _page.Locator(selector: "#Password");
        private ILocator _btnLogin => _page.Locator(selector: "text=Log in");
        private ILocator _lnkEmployeeDetails => _page.Locator(selector: "text='Employee Details'");
        private ILocator _lnkEmployeeLists => _page.Locator(selector: "text='Employee List'");

        public async Task ClickLogin()
        {
            await _page.RunAndWaitForNavigationAsync(async () =>
            {
                await _lnkLogin.ClickAsync();
            }, new PageRunAndWaitForNavigationOptions
            {
                UrlString = "**/Login"
            });
        }
        public async Task ClickEmployeeList()
        {
            await _lnkEmployeeLists.ClickAsync();
        }

        public async Task Login(string username, string password)
        {
            await _txtUserName.FillAsync(username);
            await _txtPassword.FillAsync(password);
            await _btnLogin.ClickAsync();
        }

        public async Task<bool> IsEmployeeDetailsExists() => await _lnkEmployeeDetails.IsVisibleAsync();
    }
}
