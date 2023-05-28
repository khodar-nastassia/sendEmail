﻿using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Collections.ObjectModel;

namespace SendEmail.Pages;

public abstract class BasePage
{
    protected IWebDriver _driver;
    Actions _action;
    WebDriverWait _wait;

    protected BasePage(IWebDriver driver)
    {
        _driver = driver;
        _action = new Actions(_driver);
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
    }

    protected void GoToUrl(string url)
    {
        _driver.Url = url;
        _driver.Manage().Window.Maximize();
    }

    protected void ClickElement(IWebElement webElement)
    {
        _action.MoveToElement(webElement);
        _action.Perform();
        webElement.Click();
    }

    protected ReadOnlyCollection<IWebElement> FindGoogleElements(string xPath)
    {
        return _wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(xPath)));
    }

    protected IWebElement FindGoogleElement(string xPath)
    {
        return _wait.Until(ExpectedConditions.ElementExists(By.XPath(xPath)));
    }
}
