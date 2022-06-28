using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;


namespace DAL.Convert
{
    public class UserConvert
    {
        public static UserDAL ConvertUserM(UserModel user)
        {
            return new UserDAL
            {
                user_id = user.user_id,
                userName = user.userName,
                password = user.password,
                adressUser = user.adressUser,
            };
        }

        public static UserModel ConvertUserModel(user user)
        {
            return new UserModel
            {
                user_id = user.user_id,
                userName = user.userName,
                password = user.password,
                adressUser = user.adressUser,
            };
        }
        public static List<UserModel> ConvertUserListToModel(IEnumerable<user> users)
        {
            return users.Select(c => ConvertUserModel(c)).OrderBy(n => n.user_id).ToList();
        }

    }
}
