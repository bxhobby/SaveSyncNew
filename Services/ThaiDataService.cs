using SaveSyncNew.Models;
using System.Text.Json;

namespace SaveSyncNew.Services
{
    public class ThaiDataService
    {
        private readonly string PathThaiData = Directory.GetCurrentDirectory() + @"\Data\thailand-geography-json-main\";

        private List<Province>? LoadProvinceData()
        {
            StreamReader Reader = new(PathThaiData + @"provinces.json");
            string Json = Reader.ReadToEnd();
            List<Province>? ListProvince = JsonSerializer.Deserialize<List<Province>>(Json);

            return ListProvince;
        }

        private List<District>? LoadDistrictData()
        {
            StreamReader ReaderDistrict = new(PathThaiData + @"districts.json");
            string Json = ReaderDistrict.ReadToEnd();
            List<District>? ListDistrict = JsonSerializer.Deserialize<List<District>>(Json);

            return ListDistrict;
        }

        private List<SubDistrict>? LoadSubDistrictData()
        {
            StreamReader ReaderDistrict = new(PathThaiData + @"subdistricts.json");
            string Json = ReaderDistrict.ReadToEnd();
            List<SubDistrict>? ListSubDistrict = JsonSerializer.Deserialize<List<SubDistrict>>(Json);

            return ListSubDistrict;
        }

        public List<string>? LoadProvince()
        {
            List<Province>? ProvinceData = LoadProvinceData();
            if (ProvinceData == null) return null;
            List<string> ListProvince = new();
            foreach (Province Province in ProvinceData)
            {
                if (Province.ProvinceNameTh != null)
                {
                    ListProvince.Add(Province.ProvinceNameTh);
                }
            }
            return ListProvince;
        }

        public List<string>? LoadDistrict(string ProvincName)
        {
            List<string> ListDistrict = new();

            List<Province>? ProvinceData = LoadProvinceData();
            if (ProvinceData == null) return null;

            Province? SearchProvince = ProvinceData.FirstOrDefault(p => p.ProvinceNameTh == ProvincName);
            if (SearchProvince == null) return null;

            int ProvinceCode = SearchProvince.ProvinceCode;
            List<District>? DistrictData = LoadDistrictData();
            if (DistrictData == null) return null;

            List<District> SearchListDistrict = DistrictData.Where(x => x.provinceCode == SearchProvince.ProvinceCode).ToList();
            foreach (District District in SearchListDistrict)
            {
                if (District.districtNameTh != null)
                {
                    ListDistrict.Add(District.districtNameTh);
                }
            }
            return ListDistrict;
        }

        public List<string>? LoadSubDistrict(string SelectDistrictName)
        {
            List<string> ListSubDistrict = new();

            List<District>? DistrictData = LoadDistrictData();
            if (DistrictData == null) return null;

            District? SearchDistrict = DistrictData.FirstOrDefault(x => x.districtNameTh == SelectDistrictName);
            if (SearchDistrict == null) return null;

            int DistrictCode = SearchDistrict.districtCode;
            List<SubDistrict>? SubDistrictData = LoadSubDistrictData();
            if (SubDistrictData == null) return null;


            List<SubDistrict> SearchListSubDistrict = SubDistrictData.Where(x => x.DistrictCode == SearchDistrict.districtCode).ToList();

            foreach (SubDistrict SubDistrict in SearchListSubDistrict)
            {
                if (SubDistrict.SubdistrictNameTh != null)
                {
                    ListSubDistrict.Add(SubDistrict.SubdistrictNameTh);
                }
            }
            return ListSubDistrict;
        }

        public int? LoadPostalCode(string SelectSubDistrictName, string SelectDistrictName)
        {
            List<SubDistrict>? SubDistrictData = LoadSubDistrictData();
            List<District>? DistrictData = LoadDistrictData();
            if (SubDistrictData == null || DistrictData == null) return null;

            District? SearchDistrict = DistrictData.FirstOrDefault(x => x.districtNameTh == SelectDistrictName);
            if (SearchDistrict == null) return null;

            SubDistrict? SearchSubDistrict = SubDistrictData.FirstOrDefault
            (
                x => x.SubdistrictNameTh == SelectSubDistrictName && x.DistrictCode == SearchDistrict.districtCode
            );
            if (SearchSubDistrict == null) return null;

            return SearchSubDistrict.PostalCode;
        }
    }
}
