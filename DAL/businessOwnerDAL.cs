using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;


namespace DAL
{

    public class businessOwnerDAL
    {
        close_cheapEntities1 DB = new close_cheapEntities1();
        //הוספת בעל עסק חדש
        public void Add(businessOwner businessOwner)
        {
            DB.businessOwners.Add(businessOwner);
            DB.SaveChanges();
        }

        
        ////שם החנות
        public string getNameShopById(int shop_id)
        {
            businessOwner shop = DB.businessOwners.Find(shop_id);
            return shop.adress;
        }

         ////שם משתמש
        public string GetUserByID(user user_id)
        {
            user user = DB.users.Find(user_id);
            return user.userName;

        }
    }
}
  