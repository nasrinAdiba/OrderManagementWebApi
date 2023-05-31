namespace OrderManagementWebApi.Models
{
    public class Orderinfo
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public string OrderInvoiceNo { get; set; }
        public DateTime OrderDateTime { get; set; }
        public decimal TotalPrice { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string ShippingAddress { get; set; }
        public DateTime ShippingDate { get; set; }
    }
}
