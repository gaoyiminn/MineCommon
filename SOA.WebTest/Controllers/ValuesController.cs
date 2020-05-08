using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SOA.WebTest.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> lGet()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [Route("api/values/{id:int}")]
        public string Get(int id)
        {
            return "value";
        }
        [Route("api/values/{name}")]
        public string Get(string name)
        {
            return $"value {name}";
        }


        [Route("api/values/{id:int}/Type/{typeid:int}")]
        public string Get(int id, int typeid)
        {
            return $"value {id} {typeid}";
        }

        [Route("api/values/{id}/v2")]
        public string GetV2(int id)
        {
            return "value v2";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
