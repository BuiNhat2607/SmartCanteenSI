namespace SmartCanteenSI.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderDetail")]
    public partial class OrderDetail
    {
        public long OrderDetailID { get; set; }

        public long? DishID { get; set; }

        public long? OrderID { get; set; }

        public int? Quantity { get; set; }

        public double? Price { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        public virtual Dish Dish { get; set; }

        public virtual Order Order { get; set; }
    }
}
