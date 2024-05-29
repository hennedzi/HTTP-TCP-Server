namespace Server;

internal static class RequestParser
{
    public static Request Parse(string header)
    {
        var split = header.Split(" ");
        return new Request(split[1], Broker(split[0]));
    }
    private static HttpMethod Broker(string method)
    {
        return method switch
        {
            "GET" => HttpMethod.Get,
            "POST" => HttpMethod.Post,
            "HEAD" => HttpMethod.Head,
            _ => HttpMethod.Post
        };
    }
}