
using phonebook.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace phonebook.Controllers
{
    public class PhoneController : Controller
    {
        // GET: Phone
        phonebookEntities dbObj = new phonebookEntities();
        public ActionResult Phone()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPhone(phonenumber model)
        {
            if (ModelState.IsValid)
            {
                phonenumber obj = new phonenumber();
                obj.first_name = model.first_name;
                obj.last_name = model.last_name;
                obj.phone_number = model.phone_number;

                dbObj.phonenumbers.Add(obj);
                dbObj.SaveChanges();
            }
            ModelState.Clear();
           
            return View("Phone");

        }
    }
}