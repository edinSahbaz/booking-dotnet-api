using Booking.Domain.Abstractions;
using MediatR;

namespace Booking.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}