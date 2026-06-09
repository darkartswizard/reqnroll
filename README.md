# reqnroll

Basic ReqNRoll C# browser automation example for `www.candymapper.com`.

## Project

- Solution: `CandyMapper.ReqnRoll.sln`
- Test project: `tests/CandyMapper.ReqnRoll.Tests`

## Run

```bash
dotnet test CandyMapper.ReqnRoll.sln
```

The sample launches a headless Chromium browser and navigates to `https://www.candymapper.com/`. If the site is not reachable from the current environment, the example scenario is skipped with a clear message.
