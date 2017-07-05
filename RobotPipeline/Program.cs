using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using RobotPipeline.Cadastros;
using RobotPipeline.Login;

namespace RobotPipeline
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new FirefoxDriver();
            
            var login = new RobotLogin(driver, "http://10.10.1.22:8091/");

            if (login.EfetuarLogin())
            {
                new Bairro(driver);                
            }
        }
    }
}
