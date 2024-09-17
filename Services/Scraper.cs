

using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Newtonsoft.Json.Linq;
using LinkedinScrapper.Helpers;
using LinkedinScrapper.Dtos;
using LinkedinScrapper.Entities;
using LinkedinScrapper.Repositories;

namespace LinkedinScrapper.Services
{
public class Scraper(IScrappedDataRepository _scrappedDataRepository){
    public  List<ScrappedDataEntity>
      ScrapeLinkedInProfile(
        AssignmentLinksDto assignmentLinksDto
        
    ){
        IScrappedDataRepository scrappedDataRepository = _scrappedDataRepository;

        var chromeOptions = new ChromeOptions();
        chromeOptions.AddArgument("--headless"); // Run in headless mode
        chromeOptions.AddArgument("--disable-gpu"); // Disable GPU hardware acceleration
        chromeOptions.AddArgument("--no-sandbox"); // Disable sandboxing

            
            foreach (var profileLink in assignmentLinksDto.Links)
            {
             
            try
            {
                using IWebDriver driver = new ChromeDriver(chromeOptions);
                driver.Navigate().GoToUrl(profileLink);
                var pageContent = driver.PageSource;


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
                        ScrappedDataEntity scrappedData = new ();
                        scrappedData.AssignmentId = assignmentLinksDto.AssignmentId;
                        scrappedData.LinkedinUrl = profileLink;
                        string name = person["name"]?.ToString();
                        scrappedData.Name = name;
                        string locality = person["address"]?["addressLocality"]?.ToString();
                        string country = person["address"]?["addressCountry"]?.ToString();
                        string profilePicUrl = person["image"]?["contentUrl"]?.ToString();

                        // Extracting job titles and company names
                        var jobTitles = person["jobTitle"]?.ToArray();
                        var worksFor = person["worksFor"]?.ToArray();

                    
                        if (jobTitles != null && jobTitles.Length > 0)
                        {
                          scrappedData.CompanyName = StringUtils.ExtractJobTitle(jobTitles[0].ToString());
                        }

                    
                        if (worksFor != null && worksFor.Length > 0)
                        {
                           scrappedData.JobTitle = worksFor[0]["name"]?.ToString() ?? "";

                        }

                        scrappedDataRepository.Add(scrappedData);
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
            return [.. scrappedDataRepository.GetAll(assignmentLinksDto.AssignmentId)];
        }
}
}