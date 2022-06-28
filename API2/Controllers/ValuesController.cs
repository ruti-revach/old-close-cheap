using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using DAL;
using Models;

namespace API2.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        businessOwnerDAL businessOwnerBLL = new businessOwnerDAL();
        public IEnumerable<string> Get()
        {
            businessOwnerBLL.Add(new businessOwner() { name = "ruty", adress = "vav", class_id = 5 });
            return new string[] { "ok" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
