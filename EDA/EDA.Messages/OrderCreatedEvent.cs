namespace EDA.Messages
{
    public class OrderCreatedEvent
    {
        public string CustomerName { get; set; }
        public int OrderId { get; set; }
        public List<string> Products { get; set; }
    }
}
