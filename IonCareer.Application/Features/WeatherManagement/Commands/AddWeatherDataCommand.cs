using IonCareer.Application.Contracts.Persistence;
using IonCareer.Application.Dtos;
using IonCareer.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IonCareer.Application.Features.WeatherManagement.Commands;

public sealed record AddWeatherDataCommand
    (WeatherData Data) : IRequest<List<WeatherDto>>;

internal sealed class AddWeatherDataCommandHandler : IRequestHandler<AddWeatherDataCommand, List<WeatherDto>>
{
    private readonly IIonCareerDbContext _ionCareerDbContext;

    public AddWeatherDataCommandHandler(IIonCareerDbContext ionCareerDbContext)
    {
        _ionCareerDbContext = ionCareerDbContext;
    }

    public async Task<List<WeatherDto>> Handle(AddWeatherDataCommand request, CancellationToken cancellationToken)
    {
        var weatherData = new WeatherData
        {
            Temperature = request.Data.Temperature,
            Humidity = request.Data.Humidity,
            Location = request.Data.Location
        };


        _ionCareerDbContext.WeatherDatas?.Add(weatherData);
        await _ionCareerDbContext.SaveChangesAsync(cancellationToken);

        var weather = await (_ionCareerDbContext.WeatherDatas ?? throw new NullReferenceException()).Select(data =>
                new WeatherDto
                {
                    Id = data.Id,
                    Temperature = data.Temperature,
                    Location = data.Location
                })
            .ToListAsync(cancellationToken);

        return weather;
    }
}