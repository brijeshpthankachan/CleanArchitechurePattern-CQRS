using IonCareer.Application.Contracts.Persistence;
using IonCareer.Application.Dtos;
using IonCareer.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IonCareer.Application.Features.WeatherManagement.Commands
{
    public sealed record AddWeatherDataCommand(WeatherData Data, CancellationToken CancellationToken) : IRequest<List<WeatherDto>>;



    internal sealed class AddWeatherDataCommandHandler : IRequestHandler<AddWeatherDataCommand, List<WeatherDto>>
    {
        private readonly IIonCareerDbContext _ionCareerDbContext;

        public AddWeatherDataCommandHandler(IIonCareerDbContext ionCareerDbContext)
        {
            _ionCareerDbContext = ionCareerDbContext;
        }

        public async Task<List<WeatherDto>> Handle(AddWeatherDataCommand request, CancellationToken cancellationToken)
        {
            var weather = new WeatherData()
            {
                Temperature = request.Data.Temperature,
                Humidity = request.Data.Humidity,
                Location = request.Data.Location,
            };

            _ionCareerDbContext.WeatherDatas.Add(weather);
            await _ionCareerDbContext.SaveChangesAsync(cancellationToken);

            var weathe = await _ionCareerDbContext.WeatherDatas.
               Select(weather => new WeatherDto()
               {
                   Id = weather.Id,
                   Temperature = weather.Temperature,
                   Location = weather.Location
               })
               .ToListAsync(cancellationToken);

            return weathe;
        }


    }
}
