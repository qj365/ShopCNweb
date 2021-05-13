
using ShopCNweb.Models.Entities;
using System.Linq;

namespace ShopCNweb.Dao
{
    public class TaiKhoanDAO
    {
        ModelShop db;
        public TaiKhoanDAO()
        {
            db = new ModelShop();
        }
        public bool Login(string username, string password)
        {
            var rs = db.Account.Count(x => x.USERNAME == username && x.PASSWORD == password);
            if (rs > 0)
                return true;
            return false;
        }
    }
}