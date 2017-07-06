using System;
using OpenQA.Selenium;
using RobotPipeline.Infra;

namespace RobotPipeline.Cadastros
{
    public class Bairro : Base
    {
        public string   uf = "Rio Grande do Sul",
                        ufId = "select2-chosen-4",

                        cidade = "Porto Alegre",
                        cidadeId = "select2-chosen-6",

                        bairroNomeAutomatico,

                        iddne = "12",
                        iddne_editado = "13";

        public Bairro ()
        {
            Alias = "Bairro";

            // cada vez q rodar, gerar um nome unico
            bairroNomeAutomatico = "TesteAutomatizado" + DateTime.Now.ToString("ddMMyyyyHHmm");
        }

        public void Inserir(ref IWebDriver driver)
        {
            try
            {
                Mensagem("inserir");

                BotaoNovo(driver);

                Select(driver, uf, ufId);
                Select(driver, cidade, cidadeId);
                EnviaTextoPorId(driver, "nome", bairroNomeAutomatico);
                EnviaTextoPorId(driver, "iddne", iddne);
                                
                BotaoClickByCss(driver, "div.bot-buttons button.ng-scope");

                Mensagem("inserir OK!");
            }
            catch (System.Exception ex)
            {
                Mensagem("FALHA inserir");
                Mensagem(ex.ToString());
            }
        }

        public void Pesquisar(IWebDriver driver)
        {
            try
            {
                Mensagem("pesquisar");

                EnviaTextoPorId(driver, "filtroBasico", bairroNomeAutomatico);

                BotaoClickByCss(driver, "div.filter-box button.botaoPesquisa");

                //verificar se trouxe elementos....

                Mensagem("pesquisar OK");
            }
            catch (System.Exception ex)
            {
                Mensagem("FALHA inserir");
                Mensagem(ex.ToString());                
            }
        }

        // listagem e depois edição
        public void Editar(IWebDriver driver)
        {
            try
            {
                Mensagem("editar");

                EnviaTextoPorId(driver,"filtroBasico", bairroNomeAutomatico);

                BotaoClickByCss(driver,"div.filter-box button.botaoPesquisa");

                // clica na linha
                driver.FindElement(By.CssSelector("tr.ng-scope")).Click();

                // espera carga
                Sleep(5);

                EnviaTextoPorId(driver,"iddne", iddne_editado);

                BotaoClickByCss(driver, "button.ng-scope");

                Mensagem("editar OK");
            }
            catch (System.Exception ex)
            {
                Mensagem("FALHA inserir");
                Mensagem(ex.ToString());
            }
        }
    }
}

