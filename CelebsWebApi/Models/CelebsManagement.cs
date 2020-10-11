using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CelebsWebApi.Models
{
    public class CelebsManagement
    {
        protected readonly string celebsListUrl = "";
        // contains Celebs Data
        protected readonly List<Celeb> celebsList = new List<Celeb>();

        public CelebsManagement(string celebsListUrl)
        {
            this.celebsListUrl = celebsListUrl;
        }

        public List<Celeb> CelebsList { get { return celebsList; } }

        public List<Celeb> InitCelebsList()
        {
            // Get all celebs list from imdb
            celebsList.Clear();
            HtmlWeb webImdb = new HtmlWeb();
            HtmlDocument docImdb = webImdb.Load(celebsListUrl);
            HtmlWeb webImdCelebBiography = new HtmlWeb();
            HtmlNodeCollection nodes = docImdb.DocumentNode.SelectNodes("//div[@class='lister-item mode-detail']");
            foreach (HtmlNode node in nodes)
            {
                string fullName = node.SelectNodes(".//h3[@class='lister-item-header']//a").First().InnerHtml.TrimStart().TrimEnd();
                char[] delimiterChars = { '|' };
                string title = node.SelectNodes(".//p[@class='text-muted text-small']").First().InnerText.TrimStart().Split(delimiterChars)[0].TrimEnd();
                var picture = node.SelectNodes(".//div[@class='lister-item-image']//img//@src").First().Attributes.Where(i => i.Name == "src").FirstOrDefault().Value;
                string celebBioUrl = node.SelectNodes(".//h3[@class='lister-item-header']//a//@href").First().Attributes.Where(i => i.Name == "href").FirstOrDefault().Value;
                celebBioUrl = "https://www.imdb.com/" + celebBioUrl;
                string birthDate = "unknown";

                Celeb celeb = new Celeb(fullName, birthDate, title, picture);
                celebsList.Add(celeb);

                // Optional: 
                //to get birth Data from additional bio url for each celeb.. 
                //but it slows down the loading time needs another 100 web calls.
                //HtmlDocument docImdbCelebBiography = webImdCelebBio.Load(celebBiographyUrl);
                //birthDate = docImdbCelebBiography.DocumentNode.SelectNodes(".//div[@id='name-born-info']//time").First().Attributes.Where(i => i.Name == "datetime").FirstOrDefault().Value;

            }
            WriteDataToJsonFile();

            return celebsList;
        }

        // Remove element from Celebs List at specified index
        public void RemoveCelebFromList(int[] indices)
        {
            IEnumerable<int> removeIndices = indices.Reverse();

            foreach (int index in removeIndices)
            {
                if (celebsList.ElementAtOrDefault(index) != null)
                {
                    celebsList.RemoveAt(index);
                }
            }

            WriteDataToJsonFile();
        }

        // Add new element to Celebs List
        public void AddCelebToList(Celeb celeb)
        {
            celebsList.Add(celeb);
            WriteDataToJsonFile();
        }

        // Note: Json file located in the Web Api root directory
        private void WriteDataToJsonFile()
        {
            // Write all Celebs Data to Json in application root directory (CelebsManagement\CelebsWebApi)
            string executablePath = AppDomain.CurrentDomain.BaseDirectory + "CelebsDataJson.txt";
            using (StreamWriter file = File.CreateText(executablePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, celebsList);
            }
        }
    }
}