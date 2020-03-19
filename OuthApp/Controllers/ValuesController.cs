using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace OuthApp.Controllers
{
    public class ValuesController : ApiController
    {

        [Authorize(Roles = "SuperAdmin,User,Admin")]
        [HttpGet]
        [Route("api/values/getvalues")]
        public IHttpActionResult GetValues()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var roles = identity.Claims
                .Where(s => s.Type == ClaimTypes.Role).Select(s => s.Value);

            var LogTime = identity.Claims.FirstOrDefault(s => s.Type == "LoggedOn").Value;

            return Ok("Hello :" + identity.Name + " ," + " Your Roles are :" + string.Join(",", roles.ToList()) + " Your Logged time is :"+LogTime);
        }
        // GET api/values
        [Route("api/values/getval")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //public void Delete(int id)
        //{
        //}
    }
}
