using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace MatchingEngineAutomation.Pages
{
    public class HomePage : BasePage
    {
        private const string Url = "https://www.matchingengine.com/";

        private static readonly By SolutionsTrigger = By.Id("nav-toggle-solutions");

        // Any submenu link rendered by the flyout
        private static readonly By SolutionsPanelLinks =
            By.XPath("//a[contains(@class, 'SubNavLink_linkEl')]");

        public HomePage(IWebDriver driver) : base(driver) { }

        public HomePage NavigateTo()
        {
            Driver.Navigate().GoToUrl(Url);
            return this;
        }

        /// Expands the header "Solutions" menu
        public HomePage ExpandSolutionsMenu()
        {
            var trigger = WaitForClickable(SolutionsTrigger);
            trigger.Click();

            // Confirm 'Solutions' links are visible before returning
            WaitForVisible(SolutionsPanelLinks);

            return this;
        }

        /// Returns the visible text of every item in the expanded Solutions list
        public IReadOnlyList<string> GetSolutionsListItems()
        {
            return WaitForAllVisible(SolutionsPanelLinks)
                .Select(el => el.Text.Trim())
                .Where(text => !string.IsNullOrWhiteSpace(text))
                .ToList();
        }

        /// Clicks a named entry in the open Solutions list, matched by its
        /// href slug (e.g. "Distribution-processing") rather than visible
        public DistributionProcessingPage SelectSolution(string urlSlug)
        {
            var link = WaitForClickable(By.CssSelector($"a[href*='{urlSlug}']"));
            link.Click();
            return new DistributionProcessingPage(Driver);
        }
    }
}
