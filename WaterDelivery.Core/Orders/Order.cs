using System;
using System.ComponentModel.DataAnnotations;
using WaterDelivery.Core.Common;

namespace WaterDelivery.Core.Orders
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(64)]
        public string FullName { get; set; }

        [Required]
        [MaxLength(128)]
        public string Adress { get; set; }

        [Required]
        [MaxLength(12)]
        public string Phone { get; set; }

        public byte Quantity { get; set; }

        public OrderStatus Status { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public bool IsDeleted { get; set; }
    }
}
