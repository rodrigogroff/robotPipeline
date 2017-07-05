using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

using RobotPipeline.Cadastros;
using System;

namespace RobotPipeline
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new FirefoxDriver();

            driver.Navigate().GoToUrl("http://10.10.1.22:8091/");
            IWebElement passwordTextBox = driver.FindElement(By.Name("username"));
            /*passwordTextBox.Clear();
            passwordTextBox.SendKeys("sue.helen");

            driver.FindElement(By.Id("btn-login")).Click();

            var Bairro = new Bairro();

            /*if (!Bairro.teste1(driver))
            {
                Console.WriteLine("ERRO");
                return;
            }

            if (!Bairro.pesquisar(driver))
            {
                Console.WriteLine("ERRO");
                return;
            }*/

        }
    }
}
