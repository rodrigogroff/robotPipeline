using System;
using RobotPipeline.Infra;
using OpenQA.Selenium;

namespace RobotPipeline.Login
{
    public class RobotLogin : Base
    {
        public RobotLogin(IWebDriver _driver, string url)
        {
            driver = _driver;

            driver.Navigate().GoToUrl("http://10.10.1.22:8091/");
            Sleep(1);            
        }

        public bool EfetuarLogin()
        {
            try
            {
                Mensagem("Iniciando login...");

                IWebElement passwordTextBox = driver.FindElement(By.Name("username"));

                passwordTextBox.Clear();
                passwordTextBox.SendKeys("sue.helen");

                driver.FindElement(By.Id("btn-login")).Click();

                Sleep(1);

                return true;
            }
            catch (System.Exception ex)
            {
                Mensagem("FALHA LOGIN");
                Mensagem(ex.ToString());

                return false;
            }            
        }
    }
}
