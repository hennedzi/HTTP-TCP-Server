namespace Server;

public interface IHandler
{
    void Handle(Stream networkStream, Request request);
}