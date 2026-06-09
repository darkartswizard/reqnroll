using CandyMapper.ReqnRoll.Tests.Support;
using Microsoft.Playwright;

namespace CandyMapper.ReqnRoll.Tests.Pages;

public sealed class CandyMapperPage
{
    public const string HomePageUrl = "https://www.candymapper.com/";

    private readonly IPage _page;

    public CandyMapperPage(BrowserSession browserSession)
    {
        _page = browserSession.Page ?? throw new InvalidOperationException("The browser page is not initialized.");
    }

    public string CurrentUrl => _page.Url;

    public async Task NavigateToHomePageAsync()
    {
        await _page.GotoAsync(
            HomePageUrl,
            new PageGotoOptions
            {
                WaitUntil = WaitUntilState.DOMContentLoaded,
                Timeout = 15_000
            });
    }

    public Task<string> GetTitleAsync()
    {
        return _page.TitleAsync();
    }
}
