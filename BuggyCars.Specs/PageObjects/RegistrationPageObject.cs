using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace BuggyCars.PageObjects;

public class RegistrationPageObject
{
    // The URL of registration page
    private const string RegisterUrl = "https://buggy.justtestit.org/register";

    // The selenium web driver
    private IWebDriver webDriver;

    //The default time in seconds for wait.Until
    public const int DefaultWaitInSeconds = 10;

    public RegistrationPageObject(IWebDriver webDriver)
    {
        this.webDriver = webDriver;
    }

    // Finding elements by ID or XPath
    private IWebElement UserName => webDriver.FindElement(By.Id("username"));

    private IWebElement FirstName => webDriver.FindElement(By.Id("firstName"));

    private IWebElement LastName => webDriver.FindElement(By.Id("lastName"));

    private IWebElement Password => webDriver.FindElement(By.Id("password"));

    private IWebElement ConfirmPassword => webDriver.FindElement(By.Id("confirmPassword"));

    private IWebElement RegisterButton => webDriver.FindElement(By.XPath("//button[@type='submit'][text()='Register']"));

    private IWebElement MessageAfterRegistration => webDriver.FindElement(By.XPath("//div[contains(@class,'result alert')]"));

    private IWebElement LoginInput => webDriver.FindElement(By.Name("login"));

    private IWebElement PasswordInput => webDriver.FindElement(By.Name("password"));

    private IWebElement LoginButton => webDriver.FindElement(By.XPath("//button[@type='submit'][text()='Login']"));

    public IWebElement InvalidCredentialError => webDriver.FindElement(By.XPath("//span[contains(text(), 'Invalid username/password')]"));

    private IWebElement LogoutLink => webDriver.FindElement(By.LinkText("Logout"));

    public bool IsUserLoggedIn() => LogoutLink.Displayed;

    public IWebElement Form => webDriver.FindElement(By.ClassName("form-inline"));

    public void EnterUsername(string username)
    {
        UserName.Clear();
        UserName.SendKeys(username);
    }

    public void EnterFirstName(string firstName)
    {
        FirstName.Clear();
        FirstName.SendKeys(firstName);
    }

    public void EnterLastName(string lastName)
    {
        LastName.Clear();
        LastName.SendKeys(lastName);
    }

    public void EnterPassword(string password)
    {
        Password.Clear();
        Password.SendKeys(password);
    }

    public void EnterConfirmPassword(string confirmPassword)
    {
        ConfirmPassword.Clear();
        ConfirmPassword.SendKeys(confirmPassword);
    }

    public void ClickRegister()
    {
        RegisterButton.Click();
    }

    public void OpenRegistrationPage()
    {
        webDriver.Navigate().GoToUrl(RegisterUrl);
    }

    public string GetMessageAfterRegistration()
    {
        var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(DefaultWaitInSeconds));
        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//div[contains(@class,'result alert')]")));

        string messageAfterRegistration = MessageAfterRegistration.Text;

        return messageAfterRegistration;
    }

    public void EnterLogin(string username)
    {
        LoginInput.Clear();
        LoginInput.SendKeys(username);
    }

    public void EnterLoginPassword(string loginpassword)
    {
        PasswordInput.Clear();
        PasswordInput.SendKeys(loginpassword);
    }

    public void ClickLoginButton()
    {
        LoginButton.Click();
    }

    public void ClickLogoutLink()
    {
        LogoutLink.Click();
    }


    public void WaitForElement()
    {
        Console.WriteLine("Waiting for element to be present...");
        var timeout = 10000; // in milliseconds
        var wait = new WebDriverWait(webDriver, TimeSpan.FromMilliseconds(timeout));
        wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Logout")));
    }
}