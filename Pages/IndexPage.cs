using OpenQA.Selenium;

namespace SendEmail.Pages;

internal class IndexPage:BasePage
{
    IWebElement _signInButton;

    const string MAIL_PAGE_XPATH = "//a[@data-action='sign in']";
    public IndexPage(IWebDriver driver) : base(driver)
    {
        GoToUrl("https://www.google.com/gmail/about/");
        Initialize();
    }

    public void Initialize()
    {
        _signInButton = FindGoogleElement(MAIL_PAGE_XPATH);
    }

    public LoginPage SwitchToLoginPage()
    {
        ClickElement(_signInButton);
        return new LoginPage(_driver);
    }

    public void Uninitialize()
    {
        _driver.Close();
    }
}
