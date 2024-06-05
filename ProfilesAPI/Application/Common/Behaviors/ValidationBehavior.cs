using FluentValidation;
using MediatR;

namespace Application.Common.Behaviors;

public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    public Task<TResponse> Handle(TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);
        var failures = validators
            .Select(v => v.Validate(context))
            .SelectMany(result => result.Errors)
            .Where(failure => failure != null)
            .ToList();
        
        if (failures.Count != 0)
        {
            var errorMessages = failures.Select(failure => failure.ErrorMessage).ToList().AsReadOnly();
            var errorMessage = string.Join(" ", errorMessages);
            
            throw new ValidationException(errorMessage);
        }

        return next();
    }
}