using BasicWebServer.Server;



string ip = "127.0.0.1";

int port = 8080;

var server = new HttpServer(ip, port);

server.Start();