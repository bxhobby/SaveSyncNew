using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaveSyncNew.Models
{
    [Table("Shop")]
    public class Shop
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nchar(4)")]
        public int CustomerId { get; set; }
        public string? LicenseCode { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string? ShopCode { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string? ShopName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime PayDate { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
