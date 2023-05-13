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

        [Column(TypeName = "nvarchar(50)")]
        public string? ShopCode { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? ShopName { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string? CustomerName { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string? Address { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? SubDistrict { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? District { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? Province { get; set; }

        [Column(TypeName = "int")]
        public int? PostalCode { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public string? Phone { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime RegisterDate { get; set; }
    }
}
