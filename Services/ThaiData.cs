using SaveSyncNew.Models;
using System.Text.Json;

namespace SaveSyncNew.Services
{
    public class ThaiData
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

            if (ProvinceData is not null)
            {
                List<string> ListProvince = new();
                foreach (Province Province in ProvinceData)
                {
                    if (Province.ProvinceNameTh is not null)
                    {
                        ListProvince.Add(Province.ProvinceNameTh);
                    }
                }
                return ListProvince;
            }
            else { return null; }
        }

        public List<string>? LoadDistrict(string ProvincName)
        {
            List<Province>? ProvinceData = LoadProvinceData();
            if (ProvinceData is not null)
            {
                Province? SearchProvince = ProvinceData.FirstOrDefault(p => p.ProvinceNameTh == ProvincName);
                if (SearchProvince is not null)
                {
                    int ProvinceCode = SearchProvince.ProvinceCode;
                    List<District>? DistrictData = LoadDistrictData();

                    if (DistrictData is not null)
                    {
                        List<string> ListDistrict = new();
                        List<District> SearchListDistrict = DistrictData.Where(x => x.provinceCode == SearchProvince.ProvinceCode).ToList();

                        foreach (District District in SearchListDistrict)
                        {
                            if (District.districtNameTh is not null)
                            {
                                ListDistrict.Add(District.districtNameTh);
                            }
                        }
                        return ListDistrict;
                    }
                    else { return null; }
                }
                else { return null; }
            }
            else { return null; }
        }

        public List<string>? LoadSubDistrict(string SelectDistrictName)
        {
            List<District>? DistrictData = LoadDistrictData();
            if (DistrictData is not null)
            {
                District? SearchDistrict = DistrictData.FirstOrDefault(x => x.districtNameTh == SelectDistrictName);
                if (SearchDistrict is not null)
                {
                    int DistrictCode = SearchDistrict.districtCode;
                    List<SubDistrict>? SubDistrictData = LoadSubDistrictData();

                    if (SubDistrictData is not null)
                    {
                        List<string> ListSubDistrict = new();
                        List<SubDistrict> SearchListSubDistrict = SubDistrictData.Where(x => x.DistrictCode == SearchDistrict.districtCode).ToList();

                        foreach (SubDistrict SubDistrict in SearchListSubDistrict)
                        {
                            if (SubDistrict.SubdistrictNameTh is not null)
                            {
                                ListSubDistrict.Add(SubDistrict.SubdistrictNameTh);
                            }
                        }
                        return ListSubDistrict;
                    }
                    else { return null; }
                }
                else { return null; }
            }
            else { return null; }
        }
        public int? LoadPostalCode(string SelectSubDistrictName, string SelectDistrictName)
        {
            List<SubDistrict>? SubDistrictData = LoadSubDistrictData();
            List<District>? DistrictData = LoadDistrictData();

            if (SubDistrictData is not null && DistrictData is not null)
            {
                District? SearchDistrict = DistrictData.FirstOrDefault(x => x.districtNameTh == SelectDistrictName);
                if (SearchDistrict is not null)
                {
                    SubDistrict? SearchSubDistrict = SubDistrictData.FirstOrDefault
                    (
                        x => x.SubdistrictNameTh == SelectSubDistrictName && x.DistrictCode == SearchDistrict.districtCode
                    );
                    if (SearchSubDistrict is not null)
                    {
                        return SearchSubDistrict.PostalCode;
                    }
                    else { return null; }
                }
                else { return null; }
            }
            else { return null; }
        }
    }
}
