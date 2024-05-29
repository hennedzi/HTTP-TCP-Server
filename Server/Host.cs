using System.Net;
using System.Net.Sockets;

namespace Server;

public class Host(IHandler handler)
{
    public void Start()
    {
        Console.WriteLine("Server Started V1");
        var listener = new TcpListener(IPAddress.Any, 80);
        listener.Start();
        Console.WriteLine($"{listener.Server.AddressFamily}");
        Console.WriteLine($"Local end point: {listener.LocalEndpoint}");
        
        while (true)
        {
            try
            {
                using var client = listener.AcceptTcpClient();
                using var stream = client.GetStream();
                using var reader = new StreamReader(stream);
                var firstLine = reader.ReadLine();
                
                var request = RequestParser.Parse(firstLine);
                Console.WriteLine($"///////////////////////////");
                Console.WriteLine($"Remote end pont: {client.Client.RemoteEndPoint}");
                Console.WriteLine($"Connected: {client.Client.Connected}");
                Console.WriteLine($"Handle: {client.Client.Handle}");
                Console.WriteLine($"Type of HTTP implementation: {client.Client.ProtocolType}");
                Console.WriteLine($"Method: {request.Method}");
                Console.WriteLine($"Path: {request.Path}");
                handler.Handle(stream, request);
                Console.WriteLine($"///////////////////////////");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}