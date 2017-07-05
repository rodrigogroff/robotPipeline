using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using RobotPipeline.Cadastros;
using System.Threading;

namespace RobotPipeline
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new FirefoxDriver();

            driver.Navigate().GoToUrl("http://10.10.1.22:8091/");

            #region - login - 

            Thread.Sleep(1000);
            IWebElement passwordTextBox = driver.FindElement(By.Name("username"));
            passwordTextBox.Clear();
            passwordTextBox.SendKeys("sue.helen");

            driver.FindElement(By.Id("btn-login")).Click();

            #endregion
            
            {
                var tst = new Bairro();

                tst.Inserir(driver);
                tst.Pesquisar(driver);
                tst.Editar(driver);
            }               
            
        }
    }
}
