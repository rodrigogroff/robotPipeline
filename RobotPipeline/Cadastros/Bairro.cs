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
          
        }

        public void inserir()
        {
            try
            {
                Mensagem("inserir");

                String item, itemId;
                driver.FindElement(By.CssSelector("div.dropdown span")).Click();
                Sleep(1);
                driver.FindElement(By.PartialLinkText("Bairro")).Click();
                Sleep(1);
                driver.FindElement(By.CssSelector("div.entidade__new-button-area input.entidade__new-button")).Click();
                IWebElement nomeTextBox = driver.FindElement(By.Id("nome"));
                nomeTextBox.Clear();
                nomeTextBox.SendKeys("Teste Bairro Suellen");

                item = "Rio Grande do Sul";
                itemId = "select2-chosen-4";

                if (!RetornaSelect(item, itemId, driver))
                {
                    Console.WriteLine("Erro select estado");
                }

                item = "Porto Alegre";
                itemId = "select2-chosen-6";

                if (!RetornaSelect(item, itemId, driver))
                {
                    Console.WriteLine("Erro select cidade");
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
            Sleep(1);
            driver.FindElement(By.PartialLinkText("Bairro")).Click();
            Sleep(1);
            IWebElement pesquisarTextBox = driver.FindElement(By.Id("filtroBasico"));
            pesquisarTextBox.Clear();
            pesquisarTextBox.SendKeys("Teste Suellen");
            driver.FindElement(By.CssSelector("div.filter-box button.botaoPesquisa")).Click();
            return true;
        }

        public bool editar()
        {
            driver.FindElement(By.CssSelector("tr.ng-scope")).Click();
            Sleep(1);
            IWebElement iddneTextBox = driver.FindElement(By.Id("iddne"));
            iddneTextBox.Clear();
            iddneTextBox.SendKeys("33");
            Sleep(1);
            driver.FindElement(By.CssSelector("button.ng-scope")).Click();
            Sleep(1);
            return true;
        }
    }
}

