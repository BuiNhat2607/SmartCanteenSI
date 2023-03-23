namespace SmartCanteenSI.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Favorite")]
    public partial class Favorite
    {
        [Key]
        public long FeedBackID { get; set; }

        public long? UserID { get; set; }

        public long? DishID { get; set; }

        public virtual Dish Dish { get; set; }

        public virtual User User { get; set; }
    }
}
