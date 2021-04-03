using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OrderDbFirst.Models;

namespace OrderDbFirst.Controllers.API
{
    public class DrinksController : ApiController
    {
        private OrderDBEntities db = new OrderDBEntities();

        // GET: api/Drinks
        public IEnumerable<Drink> Get()
        {
            return db.Drinks;
        }

        // GET: api/Drinks/5
        public Drink Get(int id)
        {
            return db.Drinks.SingleOrDefault(d => d.DrinkID == id);
        }

        // POST: api/Drinks
        public IHttpActionResult Post(Drink drink)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Drinks.Add(drink);
            db.SaveChanges();

            return Ok();
        }

        // PUT: api/Drinks/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Drinks/5
        public void Delete(int id)
        {
        }
    }
}
