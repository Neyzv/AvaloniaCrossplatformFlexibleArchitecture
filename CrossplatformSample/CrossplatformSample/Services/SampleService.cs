using System.Collections.Generic;

namespace CrossplatformSample.Services;

public sealed class SampleService : ISampleService
{
    public IEnumerable<string> GetDatas() => new[]
    {
        "Hello",
        "it's",
        "a",
        "service",
        "created",
        "text",
        "!"
    };
}