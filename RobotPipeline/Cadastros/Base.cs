using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using System.Text;
using System.Threading.Tasks;

namespace RobotPipeline.Cadastros
{
    public class Base
    {
        public bool RetornaSelect(string itemSelecionado, string itemId, IWebDriver driver)
        {

            IWebElement selectUF = driver.FindElement(By.Id(itemId));
            selectUF.Click();

            var item = selectUF.FindElement(By.XPath(String.Format("//li[contains(translate(., '{0}', '{1}'), '{1}')]", itemSelecionado.ToUpper(), itemSelecionado.ToLower())));
            item.Click();

            return true;
        }
    }
}
