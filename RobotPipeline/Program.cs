using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using RobotPipeline.Cadastros;
using System.Threading;

namespace RobotPipeline
{
    class Program
    {
        static void AcessaMenu(IWebDriver driver, string menu)
        {
            Thread.Sleep(500);
            //depois
            driver.FindElement(By.CssSelector("#dropCadastros span")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.PartialLinkText(menu)).Click();
            Thread.Sleep(1000);
        }

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

            Teste_Bairro(driver);
        }

        static void Teste_Bairro(IWebDriver driver)
        {
            var tst = new Bairro();

            AcessaMenu(driver, "Bairro");

            tst.Inserir(ref driver);
            tst.Pesquisar(driver);
            tst.Editar(driver);
        }
    }
}
