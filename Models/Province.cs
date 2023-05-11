using System.Text.Json.Serialization;

namespace SaveSyncNew.Models
{
    public class Province
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("provinceCode")]
        public int ProvinceCode { get; set; }

        [JsonPropertyName("provinceNameEn")]
        public string? ProvinceNameEn { get; set; }

        [JsonPropertyName("provinceNameTh")]
        public string? ProvinceNameTh { get; set; }
    }
}