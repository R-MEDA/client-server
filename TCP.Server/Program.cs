namespace TCP.Server;

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

public class WeatherTcpServer
{
    private const int Port = 13000;

    public static void Main()
    {
        TcpListener listener = new TcpListener(IPAddress.Any, Port);
        listener.Start();
        Console.WriteLine($"Server started. Listening on port {Port}...");

        while (true)
        {
            TcpClient client = listener.AcceptTcpClient();
            Console.WriteLine("Client connected.");

            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            int bytesRead = stream.Read(buffer, 0, buffer.Length);

            string json = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            Console.WriteLine($"Received JSON: {json}");

            try
            {
                WeatherData data = JsonSerializer.Deserialize<WeatherData>(json);
                Console.WriteLine($"Parsed Weather: Temp = {data.Temperature}°C, Rainfall = {data.Rainfall}mm");

                // Send acknowledgment back
                string response = "Weather data received";
                byte[] responseBytes = Encoding.ASCII.GetBytes(response);
                stream.Write(responseBytes, 0, responseBytes.Length);
            }
            catch (JsonException ex)
            {
                Console.WriteLine("Failed to parse JSON: " + ex.Message);
            }

            client.Close();
        }
    }
}
