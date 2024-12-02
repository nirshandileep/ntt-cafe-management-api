using MediatR;
using NTT.CafeManagement.Application.Infrastructure.Response;

namespace NTT.CafeManagement.Application.Infrastructure.MediatR
{
    public record CommandRequest : IRequest<IResponse>;
}
