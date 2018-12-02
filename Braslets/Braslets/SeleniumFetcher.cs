using System;
using System.IO;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Braslets
{
    class SeleniumFetcher
    {
        public SeleniumFetcher()
        {
            using (var driver = new ChromeDriver())
            {
                // Go to the home page
                driver.Navigate().GoToUrl("http://mini361.com/LoginPage/Think.Soft/login.htm");

                // Get the page elements
                var userNameField = driver.FindElementById("txtUserName");
                var userPasswordField = driver.FindElementById("txtUserPassword");
                var loginButton = driver.FindElementByCssSelector(".facebook_icon button");

                // Type user name and password
                userNameField.SendKeys("ctigran");
                userPasswordField.SendKeys("dream666");

                // and click the login button
                loginButton.Click();
                driver.Navigate().GoToUrl("http://mini361.com/Apply/Dashboard?DeviceId=34184F1854385617");
                // Extract the text and save it into result.txt
                var result = driver.FindElementById("Heart").Text;
                Console.WriteLine(result);
            }
        }
    }
}
