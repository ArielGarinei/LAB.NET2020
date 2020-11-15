namespace MVC.Entities
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Products
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Products()
        {
            Order_Details = new HashSet<Order_Details>();
        }

        [Key]
        public int ProductID { get; set; }

        [Required]
        [StringLength(40)]
        public string ProductName { get; set; }
        [JsonIgnore]
        public int? SupplierID { get; set; }
        [JsonIgnore]
        public int? CategoryID { get; set; }

        [Required]
        [StringLength(40)]
        public string QuantityPerUnit { get; set; }
        [JsonIgnore]
        [Column(TypeName = "money")]
        public decimal? UnitPrice { get; set; }
        [JsonIgnore]
        public short? UnitsInStock { get; set; }
        [JsonIgnore]
        public short? UnitsOnOrder { get; set; }
        [JsonIgnore]
        public short? ReorderLevel { get; set; }
        [JsonIgnore]
        public bool Discontinued { get; set; }
        [JsonIgnore]
        public virtual Categories Categories { get; set; }
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_Details> Order_Details { get; set; }
        [JsonIgnore]
        public virtual Suppliers Suppliers { get; set; }
    }
}
