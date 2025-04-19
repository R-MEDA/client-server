namespace TCP.Server;

// The DTO we use to Deserialize the JSON data from the client
public class WeatherData
{
    public int Temperature { get; set; }
    public int Rainfall { get; set; }
}

// The following objects should behave similarly to the WeatherData class above, but they are not. Why oh Why?

// public class WeatherData
// {
//     public int Temperature;
//     public int Rainfall;
// }

// public class WeatherData
// {
//     private int Temperature;
//     private int Rainfall;
// }

// public class WeatherData
// {
//     private int Temperature;
//     private int Rainfall;

//     public WeatherData(int temperature, int rainfall)
//     {
//         Temperature = temperature;
//         Rainfall = rainfall;
//     }
// }