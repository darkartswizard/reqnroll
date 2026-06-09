using CandyMapper.ReqnRoll.Tests.Support;
using Microsoft.Playwright;
using Reqnroll;

namespace CandyMapper.ReqnRoll.Tests.Hooks;

[Binding]
public sealed class BrowserHooks
{
    private readonly BrowserSession _browserSession;

    public BrowserHooks(BrowserSession browserSession)
    {
        _browserSession = browserSession;
    }

    [BeforeScenario]
    public async Task StartBrowserAsync()
    {
        _browserSession.Playwright = await Playwright.CreateAsync();

        var launchOptions = new BrowserTypeLaunchOptions
        {
            Headless = true
        };

        var executablePath = BrowserExecutableResolver.ResolveChromiumExecutablePath();
        if (executablePath is not null)
        {
            launchOptions.ExecutablePath = executablePath;
        }

        _browserSession.Browser = await _browserSession.Playwright.Chromium.LaunchAsync(launchOptions);
        _browserSession.Context = await _browserSession.Browser.NewContextAsync();
        _browserSession.Page = await _browserSession.Context.NewPageAsync();
    }

    [AfterScenario]
    public async Task StopBrowserAsync()
    {
        await _browserSession.DisposeAsync();
    }
}
