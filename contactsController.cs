using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using CONTACTAPPMVC.Models;

namespace CONTACTAPPMVC.Controllers
{
    public class contactsController : Controller
    {
        private MVCF db = new MVCF();

        // GET: contacts
        public ActionResult Index()
        {
            return View(db.contacts.ToList());
        }

        // GET: contacts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contact contact = db.contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        // POST: contacts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Email,DialCode,Number,Address")] contact contact)
        {
            MVCF db = new MVCF();
            var email = contact.Email;
            if (email != null) { 
            var users = (from x in db.contacts
                         where x.Email == email
                         select x).ToList();
            if (ModelState.IsValid)
            {
                if (users.Count > 0)
                {
                    ViewBag.Duplicate = "This Email: " + email + " already exist in our database.....!!!!!!!!!!!";

                }
                else
                {
                    db.contacts.Add(contact);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }}
                return View(contact);
            

        }
  

        // GET: contacts/Edit/1
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contact contact = db.contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: contacts/Edit/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Email,DialCode,Number,Address")] contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contact);
        }
        // GET: contacts/Delete/1
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);     }
            contact contact = db.contacts.Find(id);
            if (contact == null)
            {                return HttpNotFound();           }
            return View(contact);
        }

        // POST: contacts/Delete/1
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            contact contact = db.contacts.Find(id);
            db.contacts.Remove(contact);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {               db.Dispose();           }
            base.Dispose(disposing);
        }    }}
