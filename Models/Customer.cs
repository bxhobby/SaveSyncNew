using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaveSyncNew.Models
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Column(TypeName = "nchar(4)")]
        public string? LicenseCode { get; set; }
        [Column(TypeName = "nvarchar")]
        public string? ShopCode { get; set; }
        [Column(TypeName = "nvarchar")]
        public string? ShopName { get; set; }
        [Column(TypeName = "nvarchar")]
        public string? CustomerName { get; set; }
        [Column(TypeName = "nvarchar")]
        public string? Address { get; set; }
        [Column(TypeName = "nvarchar")]
        public string? SubDistrict { get; set; }
        [Column(TypeName = "nvarchar")]
        public string? District { get; set; }
        [Column(TypeName = "nvarchar")]
        public string? Province { get; set; }
        [Column(TypeName = "int")]
        public int? PostalCode { get; set; }
        [Column(TypeName = "nvarchar")]
        public string? Phone { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime RegisterDate { get; set; }
        
    }
}
