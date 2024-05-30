using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client;

public class Client
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Client ID not provided.");
            return;
        }

        int clientId = int.Parse(args[0]);
        int port = 7824 + clientId;

        TcpListener listener = new TcpListener(IPAddress.Loopback, port);
        listener.Start();
        Console.WriteLine($"Client {clientId} listening on port {port}.");

        string status = "Idle";

        while (true)
        {
            using (TcpClient client = listener.AcceptTcpClient())
            using (NetworkStream stream = client.GetStream())
            {
                // Read message length
                byte[] data = new byte[4];
                stream.Read(data, 0, 4);
                int messageLength = BitConverter.ToInt32(data, 0);

                // Read message
                data = new byte[messageLength];
                int bytesRead = 0;
                while (bytesRead < messageLength)
                {
                    bytesRead += stream.Read(data, bytesRead, messageLength - bytesRead);
                }
                string message = Encoding.UTF8.GetString(data);

                if (message == "STATUS")
                {
                    byte[] response = Encoding.UTF8.GetBytes(status);
                    byte[] lengthPrefix = BitConverter.GetBytes(response.Length);
                    stream.Write(lengthPrefix, 0, lengthPrefix.Length);
                    stream.Write(response, 0, response.Length);
                }
                else if (message == "TERMINATE")
                {
                    byte[] response = Encoding.UTF8.GetBytes("Terminating");
                    byte[] lengthPrefix = BitConverter.GetBytes(response.Length);
                    stream.Write(lengthPrefix, 0, lengthPrefix.Length);
                    stream.Write(response, 0, response.Length);
                    break; // Exit the loop to terminate the client
                }
                else
                {
                    Console.WriteLine($"Client {clientId} received command: {message}");
                    status = $"Processing command: {message}";
                    //TODO: do work here

                    status = "Idle";
                    byte[] response = Encoding.UTF8.GetBytes("Command executed");
                    byte[] lengthPrefix = BitConverter.GetBytes(response.Length);
                    stream.Write(lengthPrefix, 0, lengthPrefix.Length);
                    stream.Write(response, 0, response.Length);
                }
            }
        }

        listener.Stop();
        Console.WriteLine($"Client {clientId} terminated.");
    }
}
