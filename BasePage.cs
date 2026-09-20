using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace MatchingEngineAutomation.Pages
{
    /// Shared helpers used by every page object: explicit waits and smooth-scroll-into-view
    public abstract class BasePage
    {
        protected readonly IWebDriver Driver;
        protected readonly WebDriverWait Wait;

        protected BasePage(IWebDriver driver, TimeSpan? timeout = null)
        {
            Driver = driver;
            Wait = new WebDriverWait(driver, timeout ?? TimeSpan.FromSeconds(15));
        }

        protected IWebElement WaitForVisible(By locator) =>
            Wait.Until(ExpectedConditions.ElementIsVisible(locator));

        protected IWebElement WaitForClickable(By locator) =>
            Wait.Until(ExpectedConditions.ElementToBeClickable(locator));

        protected IReadOnlyCollection<IWebElement> WaitForAllVisible(By locator) =>
            Wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(locator));

        /// Scrolls the element to the vertical centre of the viewport
        protected void ScrollIntoView(IWebElement element)
        {
            var js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript(
                "arguments[0].scrollIntoView({block: 'center', behavior: 'instant'});",
                element);
        }
    }
}