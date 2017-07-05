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

        public bool RetornaSelect(string itemSelecionado, string itemId, IWebDriver driver)
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
    }
}
