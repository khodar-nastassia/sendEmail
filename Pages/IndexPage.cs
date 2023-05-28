using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

namespace SendEmail.Pages;

internal class IndexPage:BasePage
{

    IWebElement _signInButton;

    //const string MAIL_PAGE_XPATH = "//div[@class='gb_u gb_v'][1]";
    const string MAIL_PAGE_XPATH = "//a[@data-action='sign in']";
    public IndexPage(IWebDriver driver) : base(driver)
    {

        GoToUrl("https://www.google.com/gmail/about/");

        //var closeRekl = FindGoogleElement("//button[@id='W0wltc']");
        //ClickElement(closeRekl);
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
