using TigerParkBackend.Contracts.Order;

namespace TigerParkBackend.Application.AppData.Contexts.Order.Services;

public interface IOrderService
{
    Task<Guid?> New(CreateOrderDto dto, CancellationToken cancellationToken);
}