namespace SmartCanteenSI.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Dish
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dish()
        {
            Favorites = new HashSet<Favorite>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public long DishID { get; set; }

        public int? CategoryID { get; set; }

        [StringLength(255)]
        public string DishName { get; set; }

        public int? InStock { get; set; }

        public double? Price { get; set; }

        [StringLength(1000)]
        public string Image { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Favorite> Favorites { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
