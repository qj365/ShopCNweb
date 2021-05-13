using PagedList;
using ShopCNweb.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopCNweb.Dao
{
    public class ProductsDAO
    {
        ModelShop db;
        public ProductsDAO()
        {
            db = new ModelShop();
        }
        public IEnumerable<Products> listProducts(int pageNum, int pageSize, string name, int minp, int maxp, int idcategory) //, string maxp,string minp, int idcategory
        {

            string q = "select * from products where name LIKE '%" + name + "%' and PRICE between " + minp + " and " + maxp + "";
            if (idcategory != 0)
                q = q + "and idcategory = " + idcategory + "";
            var lst = db.Database.SqlQuery<Products>(q).ToPagedList<Products>(pageNum, pageSize);
            return lst;
        }
        public void Delete(int id)
        {
            Products product = db.Products.Find(id);
            if (product != null)
            {
                db.Products.Remove(product);
                db.SaveChanges();
            }
        }

        public int Create(string name, int price, int amount, string description, string photo, int idcategory)
        {

            Products pro = new Products();
            pro.NAME = name;
            pro.PRICE = price;
            pro.AMOUNT = amount;
            pro.DESCRIPTION = description;
            pro.PHOTO = photo;
            pro.IDCATEGORY = idcategory;
            db.Products.Add(pro);
            db.SaveChanges();
            return pro.ID;
        }
        public Products getById(int id)
        {
            return db.Products.Single(i => i.ID == id);
        }
        public void Edit(Products tmp)
        {
            Products pro = db.Products.Find(tmp.ID);
            if (pro != null)
            {
                pro.NAME = tmp.NAME;
                pro.PRICE = tmp.PRICE;
                pro.AMOUNT = tmp.AMOUNT;
                pro.DESCRIPTION = tmp.DESCRIPTION;
                pro.PHOTO = tmp.PHOTO;
                pro.IDCATEGORY = tmp.IDCATEGORY;

                db.SaveChanges();

            }
        }
        public void Add(Products pro)
        {
            db.Products.Add(pro);
            db.SaveChanges();
        }
        public Category getCategoryname(Products pro)
        {
            return db.Category.Single(i => i.ID == pro.IDCATEGORY);
        }

    }
}