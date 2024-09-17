using System;
using System.Net.Sockets;
using System.Text;

class ChatClient
{
    private TcpClient client;

    public void Start()
    {
        try
        {
            client = new TcpClient("127.0.0.1", 8080);
            Console.WriteLine("Клиент подключен к серверу!");

            // Отправка сообщения серверу
            NetworkStream stream = client.GetStream();
            byte[] data = Encoding.ASCII.GetBytes("Привет, сервер!");
            stream.Write(data, 0, data.Length);

            Console.WriteLine("Сообщение отправлено.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
    }

    static void Main(string[] args)
    {
        ChatClient client = new ChatClient();
        client.Start();
    }
}