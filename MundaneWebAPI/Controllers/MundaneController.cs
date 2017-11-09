using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MundaneWebAPI.Models;
using Newtonsoft.Json;

namespace MundaneWebAPI.Controllers
{
    public class MundaneController : ApiController
    {
        mundanedbEntities ctx = new mundanedbEntities();

        [Route("api/mundane/GenerateLoot")]
        [HttpGet]
        public IEnumerable<GenerateLoot_Result> GenerateLoot(string lootType, int numResults, bool bEnableMagicalItems, int rarityUncommon, int rarityRare)
        {
            return ctx.GenerateLoot(lootType, numResults, bEnableMagicalItems, rarityUncommon, rarityRare).ToList();
        }
        [Route("api/mundane/GetAllItems")]
        [HttpGet]
        public IEnumerable<GetAllItems_Result> GetAllItems()
        {
            return ctx.GetAllItems().ToList();
        }
        [Route("api/mundane/CreateItem")]
        [HttpPost]
        public bool CreateItem(string ItemData){
            Items NewItem = JsonConvert.DeserializeObject<Items>(ItemData);
            ctx.Items.Add(NewItem);
            ctx.SaveChanges();
            return true;
        }
        [Route("api/mundane/DeleteItem")]
        [HttpPost]
        public bool DeleteItem(int ItemID)
        {
            var Item = ctx.Items.Where(x => x.itemid == ItemID).First();
            ctx.Items.Remove(Item);
            ctx.SaveChanges();
            return true;
        }
        [Route("api/mundane/ModifyItem")]
        [HttpPost]
        public bool ModifyItem(string ItemData)
        {
            // modify item by looking at ItemData.itemid and updating fields
            Items NewData = JsonConvert.DeserializeObject<Items>(ItemData);
            Items OldData = ctx.Items.FirstOrDefault(x => x.itemid == NewData.itemid);
            ctx.Entry(OldData).CurrentValues.SetValues(NewData);
            ctx.SaveChanges();
            return true;
        }
        [Route("api/mundane/HelloWorld")]
        [HttpGet]
        public string HelloWorld()
        {
            return "Hello World";
        }
    }
}
