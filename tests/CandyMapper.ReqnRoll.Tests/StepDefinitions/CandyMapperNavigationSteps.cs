using CandyMapper.ReqnRoll.Tests.Pages;
using Microsoft.Playwright;
using Reqnroll;

namespace CandyMapper.ReqnRoll.Tests.StepDefinitions;

[Binding]
public sealed class CandyMapperNavigationSteps
{
    private readonly CandyMapperPage _candyMapperPage;

    public CandyMapperNavigationSteps(CandyMapperPage candyMapperPage)
    {
        _candyMapperPage = candyMapperPage;
    }

    [Given("the browser is ready for CandyMapper")]
    public void GivenTheBrowserIsReadyForCandyMapper()
    {
    }

    [When("I navigate to the CandyMapper home page")]
    public async Task WhenINavigateToTheCandyMapperHomePage()
    {
        try
        {
            await _candyMapperPage.NavigateToHomePageAsync();
        }
        catch (PlaywrightException ex) when (IsEnvironmentConnectivityIssue(ex))
        {
            Assert.Ignore($"Skipped because {CandyMapperPage.HomePageUrl} is not reachable from this environment. {ex.Message}");
        }
    }

    [Then("the CandyMapper page should load")]
    public async Task ThenTheCandyMapperPageShouldLoad()
    {
        Assert.That(_candyMapperPage.CurrentUrl, Does.StartWith(CandyMapperPage.HomePageUrl).IgnoreCase);
        Assert.That(await _candyMapperPage.GetTitleAsync(), Is.Not.Empty);
    }

    private static bool IsEnvironmentConnectivityIssue(PlaywrightException exception)
    {
        return exception.Message.Contains("ERR_NAME_NOT_RESOLVED", StringComparison.OrdinalIgnoreCase)
            || exception.Message.Contains("ERR_INTERNET_DISCONNECTED", StringComparison.OrdinalIgnoreCase)
            || exception.Message.Contains("ERR_CONNECTION", StringComparison.OrdinalIgnoreCase);
    }
}
