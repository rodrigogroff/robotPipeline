using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

using RobotPipeline.Cadastros;
using System;
using System.Threading;

namespace RobotPipeline
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new FirefoxDriver();

            driver.Navigate().GoToUrl("http://10.10.1.22:8091/");

            Thread.Sleep(1000);
            IWebElement passwordTextBox = driver.FindElement(By.Name("username"));
            passwordTextBox.Clear();
            passwordTextBox.SendKeys("sue.helen");

            driver.FindElement(By.Id("btn-login")).Click();

            var Bairro = new Bairro();

            /*if (!Bairro.teste1(driver)){
                Console.WriteLine("Falhou Bairro - Inserir");
                return;
            }*/

            if (!Bairro.pesquisar(driver)) {
                Console.WriteLine("Falhou Bairro - Pesquisar");
                return;
            }

            if (!Bairro.editar(driver)) {
                Console.WriteLine("Falhou Bairro - Editar");
                return;
            }

        }
    }
}
