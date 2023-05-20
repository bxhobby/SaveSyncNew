using SaveSyncNew.Data;
using SaveSyncNew.Models;

namespace SaveSyncNew.Services
{
    public class ShopService
    {
        private readonly DataContext _dbContext;
        public ShopService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string AddShop(Shop ShopData)
        {
            try
            {
                ShopData.CreateDate = DateTime.Now;
                _dbContext.Add(ShopData);
                _dbContext.SaveChanges();
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string UpdateShop(Shop ShopData)
        {
            try
            {
                _dbContext.Update(ShopData);
                _dbContext.SaveChanges();
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public void DeleteShop(Shop ShopData)
        {
            ShopData.IsDeleted = true;
            _dbContext.Update(ShopData);
            _dbContext.SaveChanges();
        }

        public List<Shop> GetShop(int CustomerId)
        {
            try
            {
                List<Shop> FindShop = _dbContext.Shop.Where(x => x.CustomerId == CustomerId).ToList();
                return FindShop;
            }
            catch (Exception ex)
            {
                return new List<Shop> { new Shop { ShopName = ex.Message } };
            }
        }

        public Shop? GetShopFormId(int Id)
        {
            try
            {
                return _dbContext.Shop.FirstOrDefault(x => x.Id == Id);
            }
            catch
            {
                return null;
            }
        }
    }
}
