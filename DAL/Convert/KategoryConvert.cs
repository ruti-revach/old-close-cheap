using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;


namespace DAL.Convert
{

    public class KategoryConvert
    {
        public static kategory ConvertKategoryM(KategoryModel kategory)
        {
            return new kategory
            {
                kategory_Id = kategory.kategory_Id,
                registered_stores_id = kategory.registered_stores_id,
                class_id = kategory.class_id,

            };
        }

        public static KategoryModel ConvertKategoryModel(kategory kategory)
        {
            return new KategoryModel
            {

                kategory_Id = kategory.kategory_Id,
                registered_stores_id = kategory.registered_stores_id,
                class_id = kategory.class_id,
            };
        }
        public static List<KategoryModel> ConvertKategoryListToModel(IEnumerable<kategory> kategories)
        {
            return kategories.Select(c => ConvertKategoryModel(c)).OrderBy(n => n.kategory_Id).ToList();
           
        }


    }


}
