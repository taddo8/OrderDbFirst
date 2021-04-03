using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OrderDbFirst.Models;
using PagedList;

namespace OrderDbFirst.Controllers
{
    public class DrinksController : Controller
    {
        private OrderDBEntities db = new OrderDBEntities();

        // GET: Drinks
        public ActionResult Index(string currentFilter, string search, int? page)
        {
            if( search != null)
            {
                page = 1;
            }
            else
            {
                search = currentFilter;
            }
            ViewBag.CurrentFilter = search;

            var drinks = from d in db.Drinks
                         select d;
            
            if(!string.IsNullOrEmpty(search))
            {
                drinks = drinks.Where(d => d.Drink1.Contains(search) || search == null);
            }

            drinks = drinks.OrderBy(d => d.DrinkID);

            int pageSize = 5;
            int pageNumber = (page ?? 1);

            return View(drinks.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Index2()
        {
            return View();
        }

        // GET: Drinks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drink drink = db.Drinks.Find(id);
            if (drink == null)
            {
                return HttpNotFound();
            }
            return View(drink);
        }

        // GET: Drinks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Drinks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DrinkID,Customer,Drink1,Size")] Drink drink)
        {
            if (ModelState.IsValid)
            {

                db.Drinks.Add(drink);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(drink);
        }

        public ActionResult Create2()
        {

            var size = db.Sizes.ToList();

            var viewModel = new DrinkViewModel
            {
                Sizes = size
            };
            return View(viewModel);
        } 

        [HttpPost]
        public ActionResult Create2(DrinkViewModel viewModel)
        {
            if(ModelState.IsValid)
            { 
                
            }

        return View();
        }   

        public ActionResult DropDown()
        {
            ViewBag.sizes = db.Sizes.ToList();
            return View();
        }

        // GET: Drinks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drink drink = db.Drinks.Find(id);
            if (drink == null)
            {
                return HttpNotFound();
            }
            return View(drink);
        }

        // POST: Drinks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DrinkID,Customer,Drink1,Size")] Drink drink)
        {
            if (ModelState.IsValid)
            {
                db.Entry(drink).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(drink);
        }

        public ActionResult Modal(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drink drink = db.Drinks.Find(id);
            db.SaveChanges();
            if(drink == null)
            {
                return HttpNotFound();
            }

            db.SaveChanges();

            return View(drink);
        }


        // GET: Drinks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drink drink = db.Drinks.Find(id);
            if (drink == null)
            {
                return HttpNotFound();
            }
            return View(drink);
        }

        // POST: Drinks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Drink drink = db.Drinks.Find(id);
            db.Drinks.Remove(drink);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
