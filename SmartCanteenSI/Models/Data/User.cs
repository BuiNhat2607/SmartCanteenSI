namespace SmartCanteenSI.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Favorites = new HashSet<Favorite>();
            Orders = new HashSet<Order>();
        }

        public long UserID { get; set; }

        [StringLength(255)]
        public string FullName { get; set; }

        [StringLength(100)]
        public string Role { get; set; }

        [StringLength(50)]
        public string Gender { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BirthDay { get; set; }

        [StringLength(10)]
        public string PhoneNumber { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        public string PassWord { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        public bool? IsValid { get; set; }

        [StringLength(255)]
        public string Image { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Favorite> Favorites { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
