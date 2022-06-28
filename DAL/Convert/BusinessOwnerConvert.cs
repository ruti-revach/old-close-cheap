using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using DAL;

namespace DAL.Convert
{
    public class BusinessOwnerConvert
    {
        public static businessOwner ConvertBusinessOwnerM(BusinessOwnersModel businessOwner)
        {
            return new businessOwner
            {
                shop_id = businessOwner.shop_id,
                name = businessOwner.name,
                adress = businessOwner.adress,
                phone = businessOwner.phone,
                class_id = businessOwner.class_id,
            };
        }
        public static BusinessOwnersModel ConvertBusinessOwnersModel(businessOwner businessOwner)
        {
            return new BusinessOwnersModel
            {

                shop_id = businessOwner.shop_id,
                name = businessOwner.name,
                adress = businessOwner.adress,
                phone = businessOwner.phone,
                class_id = businessOwner.class_id,
            };
        }
        public static List<BusinessOwnersModel> ConvertUserListToModel(IEnumerable<businessOwner> businesses)
        {
            return businesses.Select(c => ConvertBusinessOwnersModel(c)).OrderBy(n => n.shop_id).ToList();
        }
    }
}




