namespace obada.DTO;

public class orderRequest
{
    public orderRequest(int orderId, string? customerId, int? employeeId, DateTime? orderDate, DateTime? requiredDate, DateTime? shippedDate, int? shipVia, decimal? freight)
    {
        OrderId = orderId;
        CustomerId = customerId;
        EmployeeId = employeeId;
        OrderDate = orderDate;
        RequiredDate = requiredDate;
        ShippedDate = shippedDate;
        ShipVia = shipVia;
        Freight = freight;
    }

    public int OrderId { get; set; }

    public string? CustomerId { get; set; }

    public int? EmployeeId { get; set; }

    public DateTime? OrderDate { get; set; }

    public DateTime? RequiredDate { get; set; }

    public DateTime? ShippedDate { get; set; }

    public int? ShipVia { get; set; }

    public decimal? Freight { get; set; }

    public orderRequest()
    {
        
    }
    
}