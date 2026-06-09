namespace CandyMapper.ReqnRoll.Tests.Support;

internal static class BrowserExecutableResolver
{
    private static readonly string[] CandidatePaths =
    [
        Environment.GetEnvironmentVariable("PLAYWRIGHT_CHROMIUM_EXECUTABLE") ?? string.Empty,
        "/usr/bin/chromium-browser",
        "/usr/bin/chromium",
        "/usr/bin/google-chrome",
        "/usr/bin/google-chrome-stable"
    ];

    public static string? ResolveChromiumExecutablePath()
    {
        return CandidatePaths.FirstOrDefault(File.Exists);
    }
}
