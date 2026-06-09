using Microsoft.Playwright;

namespace CandyMapper.ReqnRoll.Tests.Support;

public sealed class BrowserSession : IAsyncDisposable
{
    public IPlaywright? Playwright { get; set; }

    public IBrowser? Browser { get; set; }

    public IBrowserContext? Context { get; set; }

    public IPage? Page { get; set; }

    public async ValueTask DisposeAsync()
    {
        if (Page is not null)
        {
            await Page.CloseAsync();
            Page = null;
        }

        if (Context is not null)
        {
            await Context.CloseAsync();
            Context = null;
        }

        if (Browser is not null)
        {
            await Browser.CloseAsync();
            Browser = null;
        }

        Playwright?.Dispose();
        Playwright = null;
    }
}
