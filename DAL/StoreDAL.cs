using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace DAL
{
    public class StoreDAL
    {
        close_cheapEntities DB = new close_cheapEntities();
        private object[] id;

        public override bool Equals(object obj)
        {
            return obj is StoreDAL dAL &&
                   EqualityComparer<close_cheapEntities>.Default.Equals(DB, dAL.DB) &&
                   EqualityComparer<object[]>.Default.Equals(id, dAL.id);
        }
    }

    internal class close_cheapEntities
    {
        public close_cheapEntities()
        {
        }
    }
}

        
 
