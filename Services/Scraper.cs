

using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Newtonsoft.Json.Linq;
using LinkedinScrapper.Helpers;

namespace LinkedinScrapper.Services
{
public class Scraper(){
    public async void  ScrapeLinkedInProfile(
        string profileLink
    ){

        var chromeOptions = new ChromeOptions();
        chromeOptions.AddArgument("--headless"); // Run in headless mode
        chromeOptions.AddArgument("--disable-gpu"); // Disable GPU hardware acceleration
        chromeOptions.AddArgument("--no-sandbox"); // Disable sandboxing

        using (IWebDriver driver = new ChromeDriver(chromeOptions))
        {
            try
            {
                driver.Navigate().GoToUrl(profileLink);
                var pageContent = driver.PageSource;
                Console.WriteLine(pageContent);
          

        // Load the page content into HtmlAgilityPack for parsing
        var htmlDoc = new HtmlDocument();
        htmlDoc.LoadHtml(pageContent);

        // Extract the JSON-LD script from the HTML
        var jsonLdNode = htmlDoc.DocumentNode
            .SelectSingleNode("//script[@type='application/ld+json']");

        if (jsonLdNode != null)
        {
            string jsonLdContent = jsonLdNode.InnerText;

            // Parse the JSON-LD content using Newtonsoft.Json
            var parsedJson = JObject.Parse(jsonLdContent);

            // Extracting specific fields like name, worksFor, jobTitle, and location
            var person = parsedJson["@graph"]?[0];

            if (person != null)
            {
                string name = person["name"]?.ToString();
                string locality = person["address"]?["addressLocality"]?.ToString();
                string country = person["address"]?["addressCountry"]?.ToString();
                string profilePicUrl = person["image"]?["contentUrl"]?.ToString();

                // Extracting job titles and company names
                var jobTitles = person["jobTitle"]?.ToArray();
                var worksFor = person["worksFor"]?.ToArray();

                // Output the extracted information
                Console.WriteLine($"Name: {name}");
                Console.WriteLine($"Location: {locality}, {country}");
                Console.WriteLine($"Profile Picture URL: {profilePicUrl}");

                Console.WriteLine("Job Titles:");
                if (jobTitles != null && jobTitles.Length > 0)
                {
                    Console.WriteLine(StringUtils.ExtractJobTitle(jobTitles[0].ToString()));                    
                }

                Console.WriteLine("Companies:");
                if (worksFor != null && worksFor.Length > 0)
                {
                    
                        Console.WriteLine(worksFor[0]["name"]);
                    
                }
            }
            else
            {
                Console.WriteLine("Could not find person information in JSON-LD.");
            }
        }
        else
        {
            Console.WriteLine("No JSON-LD data found in the profile.");
        }
          }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

    }
}
}