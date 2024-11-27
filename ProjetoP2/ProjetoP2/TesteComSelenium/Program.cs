using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Threading;

/*
 * Instalar os pacotes necessários:
 * Install-Package Selenium.WebDriver
 * Install-Package Selenium.WebDriver.ChromeDriver
 */

namespace ProjetoP2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new EdgeDriver();
            driver.Manage().Window.Maximize();

            try
            {
                Console.WriteLine("Iniciando o fluxo completo de teste...");

                driver.Navigate().GoToUrl("http://localhost:5173/cadastro");
                string nomeUsuario = "Teste Selenium";
                string emailUsuario = "teste@selenium.com";
                string senhaUsuario = "senha123";

                driver.FindElement(By.Id("Nome")).SendKeys(nomeUsuario);
                driver.FindElement(By.Id("Email")).SendKeys(emailUsuario);
                driver.FindElement(By.Id("Senha")).SendKeys(senhaUsuario);
                driver.FindElement(By.Name("btnRegister")).Click(); 
                Thread.Sleep(3000);

                Console.WriteLine("Registro concluído.");

                driver.Navigate().GoToUrl("http://localhost:5173/login");

                driver.FindElement(By.Id("email")).SendKeys(emailUsuario);
                driver.FindElement(By.Id("senha")).SendKeys(senhaUsuario);
                driver.FindElement(By.Name("btnLogin")).Click(); 
                Thread.Sleep(3000);

                Console.WriteLine("Login bem-sucedido.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro durante o fluxo de teste: {ex.Message}");
            }
            finally
            {
               // driver.Quit();
               // Console.WriteLine("Teste concluído.");
            }
        }
    }
}