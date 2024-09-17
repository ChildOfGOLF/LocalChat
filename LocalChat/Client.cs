using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows;

public class Client
{
    private TcpClient client;
    private NetworkStream stream;
    private Thread listenerThread;

    public Client(string serverIp, int port)
    {
        client = new TcpClient(serverIp, port);
        stream = client.GetStream();

        listenerThread = new Thread(ListenForMessages);
        listenerThread.Start();
    }

    public void SendMessage(string message)
    {
        byte[] buffer = Encoding.ASCII.GetBytes(message);
        stream.Write(buffer, 0, buffer.Length);
    }

    private void ListenForMessages()
    {
        byte[] buffer = new byte[1024];
        int bytesRead;

        while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
        {
            string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            Console.WriteLine("Сообщение получено: " + message);
        }
    }

    public void Disconnect()
    {
        stream.Close();
        client.Close();
    }
}
