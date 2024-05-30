using System.Diagnostics;
using System.Net.Sockets;
using System.Text;

namespace Host;

public class Host
{
    private static Dictionary<int, Process> workers = new Dictionary<int, Process>();
    private static int nextWorkerId = 1;

    static void Main(string[] args)
    {
        while (true)
        {
            string? choice = GetInput();

            switch (choice)
            {
                case "1":
                    StartClient();
                    break;
                case "2":
                    SendCommandToClient();
                    break;
                case "3":
                    QueryClientStatus();
                    break;
                case "4":
                    ShowAllClients();
                    break;
                case "5":
                    CloseAllClients();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    private static void ShowAllClients()
    {
        foreach (var clientId in workers.Keys)
        {
            Console.WriteLine($"Worker Id: {clientId}");
        }
    }

    private static string? GetInput()
    {
        Console.WriteLine("\n");
        Console.WriteLine("1. Start new client");
        Console.WriteLine("2. Send command to client");
        Console.WriteLine("3. Query client status");
        Console.WriteLine("4. Show all clients");
        Console.WriteLine("5. Close all clients");
        Console.WriteLine("6. Exit");
        Console.Write("Enter your choice: ");
        var choice = Console.ReadLine();
        return choice;
    }

    static void StartClient()
    {
        var clientId = nextWorkerId++;
        var process = new Process();
        process.StartInfo.FileName = "Client.exe";
        process.StartInfo.Arguments = clientId.ToString();
        process.StartInfo.CreateNoWindow = false;
        process.StartInfo.UseShellExecute = true;
        process.Start();
        workers.Add(clientId, process);
        Console.WriteLine($"Started client {clientId}.");
    }

    static void SendCommandToClient()
    {
        Console.Write("Enter client ID: ");
        if (!int.TryParse(Console.ReadLine(), out int clientId) || !workers.ContainsKey(clientId))
        {
            Console.WriteLine("Client not found.");
            return;
        }

        Console.Write("Enter command: ");
        var command = Console.ReadLine();
        SendMessage(clientId, command);
    }

    static void QueryClientStatus()
    {
        Console.Write("Enter client ID: ");
        if (!int.TryParse(Console.ReadLine(), out int clientId) || !workers.ContainsKey(clientId))
        {
            Console.WriteLine("Client not found.");
            return;
        }

        var status = SendMessage(clientId, "STATUS");
        Console.WriteLine($"Client {clientId} status: {status}");
    }

    static void CloseAllClients()
    {
        foreach (var clientId in workers.Keys)
        {
            SendMessage(clientId, "TERMINATE");
        }

        foreach (var process in workers.Values)
        {
            process.WaitForExit();
            process.Close();
        }

        workers.Clear();
        Console.WriteLine("All clients closed.");
    }

    static string SendMessage(int clientId, string? message)
    {
        string response = "";
        if (string.IsNullOrEmpty(message))
            return response;

        try
        {
            using (TcpClient client = new TcpClient("localhost", 7824 + clientId))
            using (NetworkStream stream = client.GetStream())
            {
                // Send message length
                byte[] data = Encoding.UTF8.GetBytes(message);
                byte[] lengthPrefix = BitConverter.GetBytes(data.Length);
                stream.Write(lengthPrefix, 0, lengthPrefix.Length);
                // Send message
                stream.Write(data, 0, data.Length);

                // Read response length
                data = new byte[4];
                stream.Read(data, 0, 4);
                int responseLength = BitConverter.ToInt32(data, 0);

                // Read response message
                data = new byte[responseLength];
                int bytesRead = 0;
                while (bytesRead < responseLength)
                {
                    bytesRead += stream.Read(data, bytesRead, responseLength - bytesRead);
                }
                response = Encoding.UTF8.GetString(data);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error communicating with client {clientId}: {ex.Message}");
        }
        return response;
    }
}
