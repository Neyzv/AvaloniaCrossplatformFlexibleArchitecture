using System.Collections.Generic;

namespace CrossplatformSample.Services;

public interface ISampleService
{
    IEnumerable<string> GetDatas();
}