namespace SaveSyncNew.Models
{
    public class District
    {
        public int id { get; set; }
        public int provinceCode { get; set; }
        public int districtCode { get; set; }
        public string? districtNameEn { get; set; }
        public string? districtNameTh { get; set; }
        public int postalCode { get; set; }
    }
}
