using EDA.Messages;
using MassTransit;

namespace Notification.API.Consumer
{
    public class OrderCreatedEventConsumer : IConsumer<OrderCreatedEvent>
    {
        private readonly ILogger<OrderCreatedEventConsumer> _logger;

        public OrderCreatedEventConsumer(ILogger<OrderCreatedEventConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<OrderCreatedEvent> context)
        {
            var id = context.Message.OrderId;
            var customer = context.Message.CustomerName;
            var products = string.Join(",", context.Message.Products.ToArray());
            _logger.LogInformation($"{customer} isimli müşteri, {id} nolu siparişte aldığı ürünler: {products}");

            return Task.CompletedTask;

        }
    }
}
