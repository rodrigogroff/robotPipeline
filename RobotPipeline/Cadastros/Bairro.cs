using System;
using OpenQA.Selenium;
using System.Threading;
using RobotPipeline.Infra;

namespace RobotPipeline.Cadastros
{
    public class Bairro : Base
    {
        public Bairro (IWebDriver _driver)
        {
            Alias = "Bairro";
            driver = _driver;

            inserir();
            pesquisar();
            editar();
        }

        public void inserir()
        {
            try
            {
                Mensagem("inserir");

                String item, itemId;
                driver.FindElement(By.CssSelector("div.dropdown span")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.PartialLinkText("Bairro")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.CssSelector("div.entidade__new-button-area input.entidade__new-button")).Click();
                IWebElement nomeTextBox = driver.FindElement(By.Id("nome"));
                nomeTextBox.Clear();
                nomeTextBox.SendKeys("Teste Bairro Suellen");

                item = "Rio Grande do Sul";
                itemId = "select2-chosen-4";

                if (!RetornaSelect(item, itemId, driver))
                {
                    Console.WriteLine("Erro select estado");
                    return false;
                }

                item = "Porto Alegre";
                itemId = "select2-chosen-6";

                if (!RetornaSelect(item, itemId, driver))
                {
                    Console.WriteLine("Erro select cidade");
                    return false;
                }

                IWebElement iddneTextBox = driver.FindElement(By.Id("iddne"));
                iddneTextBox.Clear();
                iddneTextBox.SendKeys("12");
                driver.FindElement(By.CssSelector("div.bot-buttons button.ng-scope")).Click();


            }
            catch (System.Exception ex)
            {
                Mensagem("FALHA inserir");
                Mensagem(ex.ToString());
            }
        }

        public bool pesquisar()
        {
            driver.FindElement(By.CssSelector("div.dropdown span")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.PartialLinkText("Bairro")).Click();
            Thread.Sleep(1000);
            IWebElement pesquisarTextBox = driver.FindElement(By.Id("filtroBasico"));
            pesquisarTextBox.Clear();
            pesquisarTextBox.SendKeys("Teste Suellen");
            driver.FindElement(By.CssSelector("div.filter-box button.botaoPesquisa")).Click();
            return true;
        }

        public bool editar()
        {
            driver.FindElement(By.CssSelector("tr.ng-scope")).Click();
            Thread.Sleep(1000);
            IWebElement iddneTextBox = driver.FindElement(By.Id("iddne"));
            iddneTextBox.Clear();
            iddneTextBox.SendKeys("33");
            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector("button.ng-scope")).Click();
            Thread.Sleep(1000);
            return true;
        }
    }
}

