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

        public string DeleteShop(Shop ShopData)
        {
            try
            {
                ShopData.IsDeleted = true;
                _dbContext.Update(ShopData);
                _dbContext.SaveChanges();
                return "Success";
            }
            catch (Exception Ex)
            {
                return Ex.Message;
            }
            
        }

        public List<Shop> GetShop(int CustomerId)
        {
            try
            {
                return _dbContext.Shop.Where(x => x.CustomerId == CustomerId & x.IsDeleted != true).ToList();
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
