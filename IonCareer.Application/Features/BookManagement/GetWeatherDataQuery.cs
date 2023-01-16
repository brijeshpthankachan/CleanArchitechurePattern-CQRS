using IonCareer.Application.Contracts.Persistence;
using IonCareer.Application.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IonCareer.Application.Features.BookManagement
{
    public class GetWeatherDataQuery : IRequest<List<WeatherDto>>
    {
    }

    public class GetAllBooksQueryHandler : IRequestHandler<GetWeatherDataQuery, List<WeatherDto>>
    {
        private readonly IIonCareerDbContext _ionCareerDbContext;

        public GetAllBooksQueryHandler(IIonCareerDbContext ionCareerDbContext)
        {
            _ionCareerDbContext = ionCareerDbContext;
        }

        public async Task<List<WeatherDto>> Handle(GetWeatherDataQuery request, CancellationToken cancellationToken)
        {
            var weather = await _ionCareerDbContext.WeatherDatas.
                Select(weather => new WeatherDto()
                {
                    Id = weather.Id,
                    Temperature = weather.Temperature,
                    Location = weather.Location
                })
                .ToListAsync(cancellationToken);

            return weather;
        }
    }
}
