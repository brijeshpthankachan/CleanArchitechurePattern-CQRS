namespace IonCareer.Domain.Entities;

public class WeatherData
{
    public int Id { get; set; }
    public string? Location { get; set; }

    public string? Temperature { get; set; }

    public int Humidity { get; set; }
}