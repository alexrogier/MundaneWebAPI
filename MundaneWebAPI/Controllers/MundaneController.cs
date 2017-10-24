using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MundaneWebAPI.Models;

namespace MundaneWebAPI.Controllers
{
    public class MundaneController : ApiController
    {
        mundanedbEntities ctx = new mundanedbEntities();
        
        [HttpGet]
        public IEnumerable<GetAllItems_Result> GetAllItems(int numResults, bool bEnableMagicalItems)
        {
            return ctx.GetAllItems(numResults, bEnableMagicalItems).ToList();
        }
        public string HelloWorld()
        {
            return "Hello World";
        }
    }
}
