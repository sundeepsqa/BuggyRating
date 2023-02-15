using BuggyCars.PageObjects;
using BuggyCars.Specs.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SpecFlowDemo.Utils;
using TechTalk.SpecFlow;


namespace BuggyCars.Steps;
[Binding]
public class PageRegistrationStepDefinitions
{
    // Page Object for Registration
    private RegistrationPageObject registrationPageObject;

    private static string login = "";

    public PageRegistrationStepDefinitions(BrowserDriver browserDriver)
    {
        registrationPageObject = new RegistrationPageObject(browserDriver.Current);
    }

    [Given(@"User is at Register Page and enters the details")]
    public void GivenUserIsAtRegisterPageAndEntersTheDetails(Table table)
    {
        var dictionary = TableExtensions.ToDictionary(table);

        if (dictionary["Username"] == "random")
        {            
            login = new Random().NextInt64().ToString();
            Console.WriteLine("Username : " + login);
        }
        else
        {
            login = dictionary["Username"];
        }

        registrationPageObject.OpenRegistrationPage();
        registrationPageObject.EnterUsername(login);
        registrationPageObject.EnterFirstName(dictionary["FirstName"]);
        registrationPageObject.EnterLastName(dictionary["LastName"]);
        registrationPageObject.EnterPassword(dictionary["Password"]);
        registrationPageObject.EnterConfirmPassword(dictionary["ConfirmPassword"]);
    }


    [When(@"User clicks on the Register button")]
    public void WhenUserClicksOnTheRegisterButton()
    {
        registrationPageObject.ClickRegister();
    }

    [Then(@"message should display (.*)")]
    public void ThenMessageShouldDisplay(string expectedMessage)
    {
        string actualMessage = registrationPageObject.GetMessageAfterRegistration();

        Assert.AreEqual(actualMessage, expectedMessage.Trim());
    }

    #region Login
    [Given(@"I enter login credentials")]
    public void GivenIEnterLoginCredentials(Table table)
    {
        registrationPageObject.OpenRegistrationPage();

        var dictionary = TableExtensions.ToDictionary(table);
        registrationPageObject.EnterLogin(dictionary["Username"]);
        registrationPageObject.EnterLoginPassword(dictionary["Password"]);
    }


    [When("I click login button")]
    public void WhenIClickLoginButton()
    {
        registrationPageObject.ClickLoginButton();
    }

    [Then("I should be logged in")]
    public void ThenIShouldBeLoggedIn()
    {
        registrationPageObject.WaitForElement();
        Assert.That(registrationPageObject.IsUserLoggedIn(), Is.True);
    }
    #endregion


    #region Logout


    [When(@"I click logout button")]
    public void WhenIClickLogoutButton()
    {
        registrationPageObject.ClickLogoutLink();
    }

    [Then(@"I should be logged out")]
    public void ThenIShouldBeLoggedOut()
    {
        Assert.That(registrationPageObject.Form.Displayed, Is.True);
    }
    #endregion

}