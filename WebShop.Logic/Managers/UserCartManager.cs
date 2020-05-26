using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using WebShop.Logic.DB;

namespace WebShop.Logic
{
    public class UserCartManager
    {
        public static void Create(int userId, int itemId)
        {
            using(var db = new DbContext())
            {
                db.UserCart.Add(new UserCart()
                {
                    UserId = userId,
                    ItemId = itemId,
                });
                db.SaveChanges();
            }
        }

        public static List<UserCart> GetByUser(int userId)
        {
            using(var db = new DbContext())
            {
                // atlasa lietotāja groza ierakstus
                var userCart = db.UserCart.Where(c => c.UserId == userId)
                    .Join(db.Items, c => c.ItemId, i => i.Id, (c, i) => new UserCart()
                    {
                        Item = i
                    }).ToList();


                return userCart;
            }
        }
        public static void Delete(int userId,int id)
        {
          
            using(var db = new DbContext())
            {
                /* var delete = db.UserCart.Where(i => i.ItemId == id && i.UserId == userId).Select(n => new UserCart()
                 {
                     Id=n.Id,
                     Item = n.Item,
                     ItemId = n.ItemId,
                     User=n.User,
                     UserId= n.UserId

                 }).ToList();

                 foreach(var del in delete)
                 {
                     db.UserCart.Remove(db.UserCart.Find(del.Id));
                     db.SaveChanges();
                 }
                 */

                db.UserCart.RemoveRange(db.UserCart.Where(i => i.ItemId == id && i.UserId == userId));
                db.SaveChanges();

            }   
        }

        public static void Clear(int userId)
        {
            using (var db = new DbContext())
            {
                db.UserCart.RemoveRange(db.UserCart.Where(i=>i.UserId == userId));
                db.SaveChanges();
            }
        }
    }
}
