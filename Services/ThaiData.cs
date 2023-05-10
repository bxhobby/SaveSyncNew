using SaveSyncNew.Models;
using System.Text.Json;

namespace SaveSyncNew.Services
{
    public class ThaiData
    {
        private readonly string PathThaiData = Directory.GetCurrentDirectory() + @"\Data\thailand-geography-json-main\";
        public List<string> LoadProvince()
        {
            List<string> ListProvince = new();

            StreamReader Reader = new(PathThaiData + @"provinces.json");
            string Json = Reader.ReadToEnd();
            List<Province>? FormJson = JsonSerializer.Deserialize<List<Province>>(Json);

            if (FormJson is not null)
            {
                foreach (Province Province in FormJson)
                {
                    if (Province.provinceNameTh is not null)
                    {
                        ListProvince.Add(Province.provinceNameTh);
                    }
                }
            }
            return ListProvince;
        }

        public List<string> LoadDistrict(string ProvincName)
        {
            List<string> ListDistrict = new();
            Province? ProviceData;

            StreamReader Reader = new(PathThaiData + @"provinces.json");
            string JsonProvince = Reader.ReadToEnd();
            List<Province>? ListProvince = JsonSerializer.Deserialize<List<Province>>(JsonProvince);
            if (ListProvince is not null)
            {
                ProviceData = ListProvince.FirstOrDefault(a => a.provinceNameTh == ProvincName);
            }

            StreamReader ReaderDistrict = new(PathThaiData + @"districts.json");
            string JsonDistrict = ReaderDistrict.ReadToEnd();
            List<District>? FormJson = JsonSerializer.Deserialize<List<District>>(JsonDistrict);

            if(ProviceData is  null)
            {
                if (FormJson is not null)
                {
                    foreach (District District in FormJson)
                    {
                        if (District.provinceCode == ProviceData.provinceCode)
                        {
                            ListDistrict.Add(District.districtNameTh);
                        }
                    }
                }
            }
            
            return ListDistrict;
        }
    }
}
