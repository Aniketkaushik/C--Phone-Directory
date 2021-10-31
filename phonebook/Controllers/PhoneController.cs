
using phonebook.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace phonebook.Controllers
{
    public class PhoneController : Controller
    {
        // GET: Phone
        phonebookEntities dbObj = new phonebookEntities();
        public ActionResult Phone(phonenumber Obj)
        {
            if (Obj != null)
                return View(Obj);
            else
                return View();
        }

        [HttpPost]
        public ActionResult AddPhone(phonenumber model)
        {
            phonenumber obj = new phonenumber();
            if (ModelState.IsValid)
            {
                obj.id = model.id;
                obj.first_name = model.first_name;
                obj.last_name = model.last_name;
                obj.phone_number = model.phone_number;

                if (model.id == 0)
                {
                    dbObj.phonenumbers.Add(obj);
                    dbObj.SaveChanges();
                }
                else
                {
                    dbObj.Entry(obj).State = EntityState.Modified;
                    dbObj.SaveChanges();
                }

                
            }
            ModelState.Clear();
           
            return View("Phone");

        }

        public ActionResult Phonelist(string searching)
        {
            var res = dbObj.phonenumbers.Where(x => x.phone_number.Contains(searching) || x.first_name.Contains(searching) || x.last_name.Contains(searching) || searching == null ).ToList();
            return View(res);
        }

        public ActionResult Delete(int id)
        {
            var res = dbObj.phonenumbers.Where(x => x.id == id).First();
            dbObj.phonenumbers.Remove(res);
            dbObj.SaveChanges();

            var list = dbObj.phonenumbers.ToList();
            return View("Phonelist", list);
        }

    }
}