using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace MatchingEngineAutomation.Pages
{
    public class DistributionProcessingPage : BasePage
    {
        private const string ExpectedHeading = "All-in-one solution for scale";
        
        // "All-in-one solution for scale" section element ID
        private const string SectionId = "distribution-processing-overview";

        private static readonly By SectionContainer = By.Id(SectionId);

        private static readonly By SectionHeading =
            By.CssSelector($"#{SectionId} h1, #{SectionId} h2, #{SectionId} h3");

        public DistributionProcessingPage(IWebDriver driver) : base(driver) { }

        public string ExpectedHeadingText => ExpectedHeading;

        public IWebElement GetScaleSectionHeading() => WaitForVisible(SectionHeading);

        public void ScrollToScaleSection() => ScrollIntoView(GetScaleSectionHeading());

        public IWebElement GetScaleSectionContainer() => WaitForVisible(SectionContainer);

        /// All non-empty text nodes under the section, for content assertions
        public IReadOnlyList<string> GetScaleSectionBodyText()
        {
            var container = GetScaleSectionContainer();
            return container
                .FindElements(By.XPath(".//*[self::p or self::li or self::h3 or self::h4 or self::h5 or self::span]"))
                .Select(el => el.Text.Trim())
                .Where(text => !string.IsNullOrWhiteSpace(text))
                .ToList();
        }
    }
}
