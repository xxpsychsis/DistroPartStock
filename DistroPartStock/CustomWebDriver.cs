using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

public class CustomWebDriver : IDisposable
{
    private IWebDriver _driver;

    public CustomWebDriver(BrowserType browserType)
    {
        switch (browserType)
        {
            case BrowserType.Chrome:
                _driver = new ChromeDriver();
                break;

            case BrowserType.Firefox:
                _driver = new FirefoxDriver();
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(browserType), browserType, null);
        }
    }

    public IWebDriver Driver => _driver;

    public void Dispose()
    {
        _driver?.Quit();
    }
}

public enum BrowserType
{
    Chrome,
    Firefox
}
