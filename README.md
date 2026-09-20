# Matching Engine — Solutions Navigation Automation

Selenium WebDriver (C#, NUnit) automation for:

1. Visit https://www.matchingengine.com/
2. Expand **Solutions** in the header
3. Assert the Solutions list is displayed
4. Click **Distribution Processing**
5. Scroll to the **"All-in-one solution for scale"** section
6. Assert that section's content

## Requirements

- Windows 11 (developed and tested on)
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Google Chrome installed locally

## Project layout

```
MatchingEngineAutomation/
├── MatchingEngineAutomation.csproj
├── Pages/
│   ├── BasePage.cs                    # shared explicit-wait / scroll-into-view helpers
│   ├── HomePage.cs                    # header + Solutions flyout
│   └── DistributionProcessingPage.cs  # "All-in-one solution for scale" section
└── Tests/
    ├── TestBase.cs                    # ChromeDriver setup/teardown
    └── SolutionsNavigationTests.cs    # end-to-end test case
```

## Running it

```bash
dotnet restore
dotnet test
```

Requires Chrome installed locally and Selenium.WebDriver 4.6+