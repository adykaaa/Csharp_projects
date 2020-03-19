using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.Collections.Generic;

namespace NcoreMovieScraperSelenium
{
    class Program
    {
        static List<string> GetLatest50FilmsList()
        {
            ChromeOptions option = new ChromeOptions();
            option.AddArgument("--headless");
            
            IWebDriver driver = new ChromeDriver(option);

            var listOfDescriptions = new List<string>();

            driver.Navigate().GoToUrl("https://ncore.cc/login.php");

            IWebElement elementForUsername = driver.FindElement(By.Name("nev"));
            elementForUsername.SendKeys("mytos13");
            IWebElement elementForPassword = driver.FindElement(By.Name("pass"));
            elementForPassword.SendKeys("sanyiiika93!!");

            driver.FindElement(By.ClassName("submit_btn")).Click();
            Thread.Sleep(1500);

            driver.FindElement(By.Id("menu_2")).Click();
            driver.FindElement(By.Id("panel_stuff")).Click();

            var engSdMoviesDropdown = driver.FindElement(By.Id("listazasi_tipus"));
            var selectFromDropdown = new SelectElement(engSdMoviesDropdown);

            selectFromDropdown.SelectByValue("xvid");
            driver.FindElement(By.Name("submit")).Click();

            var descriptions = driver.FindElements(By.ClassName("torrent_txt"));
            

            foreach (var text in descriptions)
            {
                listOfDescriptions.Add(text.Text);
            }

            driver.Quit();

         return listOfDescriptions;

        }

        static void Main(string[] args)
        {
            var listOfMovies = GetLatest50FilmsList();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/Latest50Movies.txt";

            TextWriter tw = new StreamWriter(path);

            foreach (var movie in listOfMovies)
            {
                tw.WriteLine(movie + "\n");
            }

            tw.Close();

        }
    }
}
