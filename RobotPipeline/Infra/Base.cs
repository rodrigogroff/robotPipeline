using System;
using OpenQA.Selenium;
using System.Threading;

namespace RobotPipeline.Infra
{
    public class Base
    {
        public IWebDriver driver;
        public string Alias = "";

        public void Sleep(int segundos)
        {
            Thread.Sleep(segundos * 1000);
        }

        public void Mensagem(string msg)
        {
            Console.WriteLine(Alias + " " + DateTime.Now.ToString() + " -> " + msg);
        }

        public void AcessaMenu(string nome)
        {
            driver.FindElement(By.CssSelector("div.dropdown span")).Click();
            Sleep(1);
            driver.FindElement(By.PartialLinkText(nome)).Click();
            Sleep(1);
        }

        public void BotaoNovo()
        {
            driver.FindElement(By.CssSelector("div.entidade__new-button-area input.entidade__new-button")).Click();
        }

        public void BotaoClick(string botao)
        {
            driver.FindElement(By.CssSelector(botao)).Click();

           
        }

        public bool Select(string itemSelecionado, string itemId, IWebDriver driver)
        {
            IWebElement selectUF = driver.FindElement(By.Id(itemId));
            selectUF.Click();
            var item = selectUF.FindElement(
                By.XPath ( String.Format("//li[contains(translate(., '{0}', '{1}'), '{1}')]", 
                           itemSelecionado.ToUpper(), 
                           itemSelecionado.ToLower())));

            item.Click();
            return true;
        }

        public void EnviaTextoPorId(string id, string valor)
        {
            IWebElement txt = driver.FindElement(By.Id(id));
            txt.Clear();
            txt.SendKeys(valor);
        }
    }
}
