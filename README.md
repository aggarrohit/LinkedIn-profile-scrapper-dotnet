# LinkedIn-profile-scrapper-dotnet

## ASP.NET core WebApi with Entity Framework, in-memory database and swagger

### How to run

    1. install dotnet cli
    2. clone this repository
    3. build project with "dotnet build"
    4. run project with "dotnet run"

### Things you can do

    1. Add assignment with name and company name
    2. Delete assignment
    3. Update assignment
    4. Get all assignments
    5. add linkedin profile urls to an assignment and get profile details like name, company and job title

### Scraping Details

    1. System opens chrome browser in headless mode
    2. Navigates to user's profile
    3. Extracts user's public profile data
    4. Parse data into required format

### Libraries used for scraping

    1. HtmlAgilityPack
    2. Selenium.WebDriver
    3. Selenium.WebDriver.ChromeDriver

### Access APIs

    After running the project, APIs could be accessed via swagger on the given url
    http://localhost:5253/swagger/index.html

### Swagger

![Alt text](./sample-images/swagger.png)

### Add Assignment

![Alt text](./sample-images/add-assignment.png)

### Get Assignments

![Alt text](./sample-images/get-assignments.png)

### Scrap Linkedin profiles

![Alt text](./sample-images/scrapper.png)
