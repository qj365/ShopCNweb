using ShopCNweb.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopCNweb.Dao
{
    public class CategoryDAO
    {
        ModelShop db;
        public CategoryDAO()
        {
            db = new ModelShop();
        }
        public IEnumerable<string> listNameCategory()
        {
            var lst = db.Database.SqlQuery<string>("select name from category").ToList();
            return lst;
        }
        public Category getIdByName(string name)
        {
            return db.Category.Single(i => i.NAME == name);
        }
        public List<Category> ListCate()
        {
            return db.Category.ToList();
        }

    }
}