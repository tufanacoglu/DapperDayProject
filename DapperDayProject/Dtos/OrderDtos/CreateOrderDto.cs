namespace DapperDayProject.Dtos.OrderDtos
{
    public class CreateOrderDto
    {
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductCount { get; set; }
        public int CustomerId { get; set; }
    }
}
