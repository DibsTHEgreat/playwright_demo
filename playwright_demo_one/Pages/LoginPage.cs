using Microsoft.Playwright;

namespace PlaywrightDemo.Pages
{
    internal class LoginPage
    {
        private IPage _page;
        // Value set operation
        private readonly ILocator _lnkLogin;
        private readonly ILocator _txtUserName;
        private readonly ILocator _txtPassword;
        private readonly ILocator _btnLogin;
        private readonly ILocator _lnkEmployeeDetails;

        public LoginPage(IPage page)
        {
            _page = page;

            // Initializing all the values for the locators
            _lnkLogin = _page.Locator(selector: "text=Login");
            _txtUserName = _page.Locator(selector: "#UserName");
            _txtPassword = _page.Locator(selector: "#Password");
            _btnLogin = _page.Locator(selector: "text=Log in");
            _lnkEmployeeDetails = _page.Locator(selector: "text='Employee Details'");
        }

        public async Task ClickLogin() => await _lnkLogin.ClickAsync();

        public async Task Login(string username, string password)
        {
            await _txtUserName.FillAsync(username);
            await _txtPassword.FillAsync(password);
            await _btnLogin.ClickAsync();
        }

        public async Task<bool> IsEmployeeDetailsExists() => await _lnkEmployeeDetails.IsVisibleAsync();

    }
}
