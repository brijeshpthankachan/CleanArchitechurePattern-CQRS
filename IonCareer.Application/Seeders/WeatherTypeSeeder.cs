using IonCareer.Domain.Entities;

namespace IonCareer.Application.Seeders;

public static class WeatherTypeSeeder
{
    public static List<WeatherData> GetData()
    {
        return new List<WeatherData>
        {
            new()
            {
                Humidity = 2,
                Id = 6,
                Location = "Loc5",
                Temperature = "40"
            },
            new()
            {
                Humidity = 0,
                Id = 1,
                Location = "Loc4",
                Temperature = "40"
            },
            new()
            {
                Humidity = 0,
                Id = 2,
                Location = "Loc3",
                Temperature = "40"
            },
            new()
            {
                Humidity = 0,
                Id = 3,
                Location = "Loc3",
                Temperature = "40"
            }
        };
    }
}