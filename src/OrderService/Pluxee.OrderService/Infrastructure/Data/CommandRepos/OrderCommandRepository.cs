using Pluxee.Infrastructure.Data.EfCore;
using Pluxee.OrderService.Domain.Order;

namespace Pluxee.OrderService.Infrastructure.Data.CommandRepos;

public class OrderCommandRepository(BaseDbContext dbContext) : EfRepository<Order>(dbContext), IOrderCommandRepository;