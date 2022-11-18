using System;
using System.Collections.Generic;
using obada.DTO;

namespace obada.Models;

public partial class Order
{
    // public Order(orderRequest order)
    // {
    //     this.CustomerId = order.CustomerId;
    //     this.EmployeeId = order.EmployeeId;
    //     this.OrderDate = order.OrderDate;
    //     this.RequiredDate = order.RequiredDate;
    //     this.ShippedDate = order.ShippedDate;
    //     this.ShipVia = order.ShipVia;
    //     this.Freight = order.Freight;
    // }

    
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
