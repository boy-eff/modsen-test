using FluentValidation;
using ModsenEventService.Application.Dtos;

namespace ModsenEventService.Application.Helpers.FluentValidation;

public class ModsenEventValidator : AbstractValidator<ModsenEventDto>
{
    public ModsenEventValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Place).NotEmpty();
        RuleFor(x => x.Speaker).NotEmpty();
        RuleFor(x => x.Theme).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.Time).NotEmpty();
    }
}