using System;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;

class WeatherTcpClient
{
  private const string ServerIp = "127.0.0.1";
  private const int Port = 13000;

  public static void Main()
  {
    Random random = new();

    while (true)
    {
      // Simulate weather data
      object data = new()
      {
        Temperature = random.Next(-10, 30),
        Rainfall = random.Next(0, 100)
      };

      string json = JsonSerializer.Serialize(data);
      Console.WriteLine($"Sending: {json}");

      try
      {
        using TcpClient client = new TcpClient(ServerIp, Port);
        NetworkStream stream = client.GetStream();

        byte[] jsonBytes = Encoding.ASCII.GetBytes(json);
        stream.Write(jsonBytes, 0, jsonBytes.Length);

        // Get response from server
        byte[] responseBuffer = new byte[256];
        int bytesRead = stream.Read(responseBuffer, 0, responseBuffer.Length);
        string response = Encoding.ASCII.GetString(responseBuffer, 0, bytesRead);
        Console.WriteLine($"Server Response: {response}");
      }
      catch (SocketException ex)
      {
        Console.WriteLine($"Socket error: {ex.Message}");
      }

      Thread.Sleep(1000);
    }
  }
}