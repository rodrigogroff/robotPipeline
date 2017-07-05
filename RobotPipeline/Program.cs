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

            /*if (!Bairro.inserir(driver)){
                Console.WriteLine("Falhou Bairro - Inserir");
                return;
            }
            else{
                Console.WriteLine("Bairro - Inserir : Ok");
                return;

            }*/

            if (!Bairro.pesquisar(driver)){
                Console.WriteLine("Falhou Bairro - Pesquisar");
                return;
            }
            else {
                Console.WriteLine("Bairro - Pesquisar : Ok");
                return;
            }

            if (!Bairro.editar(driver)){
                Console.WriteLine("Falhou Bairro - Editar");
                return;
            }
            else {
                Console.WriteLine("Bairro - Editar : Ok");
                return;
            }

        }
    }
}
