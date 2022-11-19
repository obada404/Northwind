using System;
using System.Collections.Generic;
using obada.DTO;

namespace obada.Models;

public partial class Order
{
   

    public Order(orderRequest order)
    {
        this.CustomerId = order.CustomerId;
        this.EmployeeId = order.EmployeeId;
        this.OrderDate = order.OrderDate;
        this.RequiredDate = order.RequiredDate;
        this.ShippedDate = order.ShippedDate;
        this.ShipVia = order.ShipVia;
        this.Freight = order.Freight;
    
        ShipName = "";
        ShipAddress = "";
        ShipCity = "";
        ShipRegion = "";
        ShipPostalCode = "";
        ShipCountry = "";
        Customer = null;
        Employee = null;
        ShipViaNavigation = null;
    }

    public Order(int OrderId, string? CustomerId, int? EmployeeId, DateTime? OrderDate, DateTime? RequiredDate, DateTime? ShippedDate, 
        int? ShipVia, decimal? Freight, string? ShipName, string? ShipAddress, string? ShipCity, string? ShipRegion, string? ShipPostalCode,
        string? ShipCountry )
    {
       this.OrderId = OrderId;
       this.CustomerId = CustomerId;
       this.EmployeeId = EmployeeId;
       this.OrderDate = OrderDate;
       this.RequiredDate = RequiredDate;
       this.ShippedDate = ShippedDate;
       this.ShipVia = ShipVia;
       this.Freight = Freight;
       this.ShipName = ShipName;
       this.ShipAddress = ShipAddress;
       this.ShipCity = ShipCity;
       this.ShipRegion = ShipRegion;
       this.ShipPostalCode = ShipPostalCode;
       this.ShipCountry = ShipCountry;

    }

    public int OrderId { get; set; }

    public string? CustomerId { get; set; }

    public int? EmployeeId { get; set; }

    public DateTime? OrderDate { get; set; }

    public DateTime? RequiredDate { get; set; }

    public DateTime? ShippedDate { get; set; }

    public int? ShipVia { get; set; }

    public decimal? Freight { get; set; }

    public string? ShipName { get; set; }

    public string? ShipAddress { get; set; }

    public string? ShipCity { get; set; }

    public string? ShipRegion { get; set; }

    public string? ShipPostalCode { get; set; }

    public string? ShipCountry { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; } = new List<OrderDetail>();

    public virtual Shipper? ShipViaNavigation { get; set; }
}
