using System.Collections.Generic;
using DAL;

namespace BLL
{
    public class AllShops
    {
        private string[] allShops = new string[9];
        private List<string>[] Shops = new List<string>[9];

        public AllShops()
        {
            this.allShops[0] = "fox";
            this.allShops[1] = "zara";
            this.allShops[2] = "stradivarius";
            this.allShops[3] = "lider";
            this.allShops[4] = "chamis";
            this.allShops[5] = "rahitim";
            this.allShops[6] = "shoes";
            this.allShops[7] = "printop";
            this.allShops[8] = "pharm10";

        }
    }
}

