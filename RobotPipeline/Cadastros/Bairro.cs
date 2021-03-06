﻿using System;
using System.Linq;
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
            bairroNomeAutomatico = "TESTEAUTOMATIZADO " + DateTime.Now.ToString("ddMMyyyyHHmmss");
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

                Sleep(2);

                var labelPesquisa = driver.FindElements(By.CssSelector(".ng-scope td.ng-binding")).FirstOrDefault();

                if (labelPesquisa.Text != bairroNomeAutomatico)
                    Mensagem("FALHA - nome difere!");

                Mensagem("pesquisar OK");
            }
            catch (System.Exception ex)
            {
                Mensagem("FALHA pesquisar");
                Mensagem(ex.ToString());                
            }
        }
                
        public void Editar(IWebDriver driver)
        {
            try
            {
                Mensagem("editar");

                EnviaTextoPorId(driver,"filtroBasico", bairroNomeAutomatico);

                BotaoClickByCss(driver,"div.filter-box button.botaoPesquisa");
                BotaoClickByCss(driver, "tr.ng-scope");

                Sleep(2);

                // verificar se tudo q foi inserido foi salvo no banco

                IWebElement labelPesquisa = driver.FindElement(By.CssSelector("div.col-sm-10 input#nome"));


                var lst = driver.FindElements(By.CssSelector("input"));

                foreach (var item in lst)
                {
                    string t = item.GetAttribute("text");
                    string v = item.GetAttribute("value");

                    int u = 0;
                }


                // atualiza

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

