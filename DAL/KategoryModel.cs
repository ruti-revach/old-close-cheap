using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class KategoryModel
    {
        public string kategory_Id { get; set; }
        public int registered_stores_id { get; set; }
        public int class_id { get; set; }
        public object user_id { get; internal set; }
    }
}
