using System;
using MatchingEngineAutomation.Pages;
using NUnit.Framework;

namespace MatchingEngineAutomation.Tests
{
    public class SolutionsNavigationTests : TestBase
    {
        // List of "Solutions"
        private static readonly string[] ExpectedSolutions =
        {
            "Music and copyright solutions",
            "Repertoire management",
            "Repertoire and usage matching",
            "Data ingestion and integration",
            "Distribution processing",
            "Member management",
            "Member self service"
        };

        // The href slug for the Distribution Processing sub-page
        private const string DistributionProcessingSlug = "Distribution-processing";

        [Test]
        public void Solutions_Menu_Navigates_To_DistributionProcessing_And_Shows_ScaleSection()
        {
            var home = new HomePage(Driver).NavigateTo();

            // 1. Expand Solutions and assert the list is displayed.
            home.ExpandSolutionsMenu();
            var items = home.GetSolutionsListItems();

            Assert.That(items, Is.Not.Empty, "Solutions flyout should list at least one solution.");

            foreach (var expected in ExpectedSolutions)
            {
                Assert.That(items, Has.Some.Matches<string>(
                        i => i.IndexOf(expected, StringComparison.OrdinalIgnoreCase) >= 0),
                    $"Expected '{expected}' to appear in the Solutions list, but got: [{string.Join(", ", items)}]");
            }

            // 2. Click Distribution Processing.
            var distributionProcessingPage = home.SelectSolution(DistributionProcessingSlug);

            // 3. Scroll to the "All-in-one solution for scale" section.
            distributionProcessingPage.ScrollToScaleSection();

            var heading = distributionProcessingPage.GetScaleSectionHeading();
            Assert.That(heading.Displayed, Is.True, "Scale section heading should be visible after scrolling.");
            Assert.That(heading.Text.Trim(), Does.Contain(distributionProcessingPage.ExpectedHeadingText));

            // 4. Assert the section's content.
            var bodyText = distributionProcessingPage.GetScaleSectionBodyText();
            Assert.That(bodyText, Is.Not.Empty,
                "The 'All-in-one solution for scale' section should render body text.");
            Assert.That(bodyText, Has.Some.Contains("Distribute royalty payments quickly"));
            Assert.That(bodyText, Has.Some.Contains("Provide full detail of music usage to members"));
            Assert.That(bodyText, Has.Some.Contains("Reduce cost-to-distribution ratios"));
            Assert.That(bodyText, Has.Some.Contains("Prevent missing payments"));
            Assert.That(bodyText, Has.Some.Contains("Comply with international standards"));
            Assert.That(bodyText, Has.Some.Contains("Run analytics and queries"));
            Assert.That(bodyText, Has.Some.Contains("Manage different collection share pictures"));
            Assert.That(bodyText, Has.Some.Contains("Minimise manual intervention"));
            Assert.That(bodyText, Has.Some.Contains("Tackle fluctuating data volumes"));
        }
    }
}
