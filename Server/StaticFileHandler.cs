using System.Net;

namespace Server;

public class StaticFileHandler(string path) : IHandler
{
    public void Handle(Stream networkStream, Request request)
    {
        if(request.Method == HttpMethod.Get)
            Get(networkStream,request);
        if (request.Method == HttpMethod.Head)
            Head(networkStream, request);
    }

    private void Head(Stream networkStream, Request request)
    {
        using var writer = new StreamWriter(networkStream);
        var filePath = Path.Combine(path, request.Path.Substring(1));
        ResponseWriter.WriteStatus(HttpStatusCode.OK, networkStream);
                
        
        
        Console.WriteLine($"Status code: {201} OK!");
            
                
        Console.WriteLine(filePath);
    }

    private void Get(Stream networkStream, Request request)
    {
        using var writer = new StreamWriter(networkStream);
        var filePath = Path.Combine(path, request.Path.Substring(1));
                
        if (!File.Exists(filePath))
        {
            Console.WriteLine($"Status code: {404} Not found!");
            ResponseWriter.WriteStatus(HttpStatusCode.NotFound, networkStream);
        }
        else
        {
            ResponseWriter.WriteStatus(HttpStatusCode.OK, networkStream);
            using (var fileStream = File.OpenRead(filePath))
            {
                fileStream.CopyTo(networkStream);
            }
            Console.WriteLine($"Status code: {201} OK!");
        }
                
        Console.WriteLine(filePath);
    }
    
}