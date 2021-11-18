using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace issFinacial.API
{
    [EnableCors(origins: "*", headers: "*", methods: "*")] // tune to your needs
    [RoutePrefix("api/Home")]
    public class apiHomeController : ApiController
    {
        [HttpGet]
        [Route("Test")]
        public string Test()
        {
            return "Hello World";
        }
    }
}
