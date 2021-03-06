﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace RobotPipeline.Cadastros
{
    public class Bairro : Base
    {
        public bool teste1(IWebDriver driver)
        {
            String item, itemId;
            driver.FindElement(By.CssSelector("div.dropdown span")).Click();
            driver.FindElement(By.PartialLinkText("Bairro")).Click();
            driver.FindElement(By.CssSelector("div.entidade__new-button-area input.entidade__new-button")).Click();
            IWebElement nomeTextBox = driver.FindElement(By.Id("nome"));
            nomeTextBox.Clear();
            nomeTextBox.SendKeys("Teste Suellen");

            item = "santa catarina";
            itemId = "select2-chosen-4";

            if (!RetornaSelect(item, itemId, driver))
            {
                Console.WriteLine("ERRO");
                return false;
            }

            item = "blumenau";
            itemId = "select2-chosen-6";

            if (!RetornaSelect(item, itemId, driver))
            {
                Console.WriteLine("ERRO");
                return false;
            }

            IWebElement iddneTextBox = driver.FindElement(By.Id("iddne"));
            iddneTextBox.Clear();
            iddneTextBox.SendKeys("12");

            driver.FindElement(By.CssSelector("div.bot-buttons button.ng-scope")).Click();
            return true;
        }

        public bool pesquisar(IWebDriver driver) {

            driver.FindElement(By.CssSelector("div.dropdown span")).Click();
            driver.FindElement(By.PartialLinkText("Bairro")).Click();
            IWebElement pesquisarTextBox = driver.FindElement(By.Id("filtroBasico"));
            pesquisarTextBox.Clear();
            pesquisarTextBox.SendKeys("Teste Suellen");
            driver.FindElement(By.CssSelector("div.filter-box button.botaoPesquisa")).Click();
         
            return true;
        }
    }
}
