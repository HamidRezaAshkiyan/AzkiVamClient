using Newtonsoft.Json;
using System.Net.Mime;
using System.Text;

namespace AzkiVamClient.Common;

public static class HttpClientHelpers
{
    public static string ToJsonString(this object src)
        => JsonConvert.SerializeObject(src);

    public static StringContent ToStringContent(this string src)
        => new(src, Encoding.UTF8, MediaTypeNames.Application.Json);
}

