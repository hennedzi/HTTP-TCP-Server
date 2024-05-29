using Server;

var host = new Host(new StaticFileHandler("C:\\MyDirecory\\Test"));

host.Start();