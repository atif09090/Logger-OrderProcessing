namespace Logger_OrderProcessing.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string UserEmail { get; set; } = string.Empty;
    }
}
