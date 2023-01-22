using FluentValidation;

namespace IonCareer.Application.Features.WeatherManagement.Commands;

public class AddWeatherDataCommandValidator : AbstractValidator<AddWeatherDataCommand>
{
    public AddWeatherDataCommandValidator()
    {
        RuleFor(x => x.Data.Location).NotNull().MaximumLength(5).WithMessage("Location's length Cannot exceed 5").WithName("Location");
        RuleFor(x => x.Data.Temperature).NotNull();
        RuleFor(x => x.Data.Humidity).NotNull();
    }
}