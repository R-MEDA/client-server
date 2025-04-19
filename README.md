# 🌦️ TCP IoT Weather System

A simple C# TCP client-server project simulating IoT weather devices sending data to a central processor.

## 🧱 Projects

- **TCP.Client** – Simulates an IoT device sending JSON weather data every second.
- **TCP.Server** – Listens on port `13000`, receives and processes weather data.

## 🚀 How to Run

### 1. Start the Server

```bash
cd TCP.Server
dotnet run
```

### 2. Start the Client (in another terminal)

```bash
cd TCP.Client
dotnet run
```

## 🧪 Sample Output

### Client
```
Sending: {"Temperature":23,"Rainfall":60}
Server Response: Weather data received
```

### Server
```
Received JSON: {"Temperature":23,"Rainfall":60}
Parsed Weather: Temp = 23°C, Rainfall = 60mm
```

## 📌 Notes

- Messages are sent as JSON over TCP.
- Data includes `Temperature` and `Rainfall`.
- The server sends back a simple acknowledgment.
