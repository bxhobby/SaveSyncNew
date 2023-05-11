using System.Text.Json.Serialization;

namespace SaveSyncNew.Models
{
    public class SubDistrict
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("provinceCode")]
        public int ProvinceCode { get; set; }

        [JsonPropertyName("districtCode")]
        public int DistrictCode { get; set; }

        [JsonPropertyName("subdistrictCode")]
        public int SubdistrictCode { get; set; }

        [JsonPropertyName("subdistrictNameEn")]
        public string? SubdistrictNameEn { get; set; }

        [JsonPropertyName("subdistrictNameTh")]
        public string? SubdistrictNameTh { get; set; }

        [JsonPropertyName("postalCode")]
        public int PostalCode { get; set; }
    }
}
