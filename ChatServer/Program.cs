using System;
using System.Net;
using System.Net.Sockets;

class ChatServer
{
    private TcpListener listener;

    public void Start()
    {
        listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 8080);
        listener.Start();
        Console.WriteLine("Сервер запущен и ожидает подключений...");

        while (true)
        {
            TcpClient client = listener.AcceptTcpClient();
            Console.WriteLine("Клиент подключен!");
        }
    }

    static void Main(string[] args)
    {
        ChatServer server = new ChatServer();
        server.Start();
    }
}
