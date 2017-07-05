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

        public void Inserir(IWebDriver driver)
        {
            try
            {
                Mensagem("inserir");
                AcessaMenu("Bairro");

                BotaoNovo();

                Select(uf, ufId, driver);
                Select(cidade, cidadeId, driver);
                EnviaTextoPorId("nome", bairroNomeAutomatico);
                EnviaTextoPorId("iddne", iddne);

                Sleep(30);
                                
                BotaoClick("div.bot-buttons button.ng-scope");
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
                AcessaMenu("Bairro");

                EnviaTextoPorId("filtroBasico", bairroNomeAutomatico);

                BotaoClick("div.filter-box button.botaoPesquisa");
            
                //verificar se trouxe elementos....

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
                AcessaMenu("Bairro");

                EnviaTextoPorId("filtroBasico", bairroNomeAutomatico);

                BotaoClick("div.filter-box button.botaoPesquisa");

                // clica na linha
                driver.FindElement(By.CssSelector("tr.ng-scope")).Click();
                // espera carga
                Sleep(5);

                EnviaTextoPorId("iddne", iddne_editado);

                Sleep(1);

                driver.FindElement(By.CssSelector("button.ng-scope")).Click();
                Sleep(1);
            }
            catch (System.Exception ex)
            {
                Mensagem("FALHA inserir");
                Mensagem(ex.ToString());
            }
        }
    }
}

