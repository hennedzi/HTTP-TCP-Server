﻿using System.Net;

namespace Server;

internal static class ResponseWriter
{
    public static void WriteStatus(HttpStatusCode code, Stream stream)
    {
        using var writer = new StreamWriter(stream, leaveOpen: true);
        writer.WriteLine($"HTTP/1.0 {(int)code} {code}");
        writer.WriteLine();
    }
}