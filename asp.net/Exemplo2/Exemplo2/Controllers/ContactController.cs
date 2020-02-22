using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exemplo2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exemplo2.Controllers
{
    public class ContactController : Controller
    {
        private static List<ContactViewModel> contacts = new List<ContactViewModel>();
        private static int generatedId = 0;

        // GET: Contact
        public ActionResult Index()
        {
            return View(contacts);
        }

        // GET: Contact/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Contact/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contact/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                ContactController.generatedId++;
                var contact = new ContactViewModel();
                contact.Id = ContactController.generatedId;
                contact.Nome = collection["Nome"];
                contact.Idade = Convert.ToInt32(collection["Idade"]);
                ContactController.contacts.Add(contact);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Contact/Edit/5
        public ActionResult Edit(int id)
        {
            var contact = ContactController.contacts.First(x => x.Id == id);
            return View(contact);
        }

        // POST: Contact/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                var contact = ContactController.contacts.First(x => x.Id == id);
                contact.Nome = collection["Nome"];
                contact.Idade = Convert.ToInt32(collection["Idade"]);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Contact/Delete/5
        public ActionResult Delete(int id)
        {
            var contact = ContactController.contacts.First(x => x.Id == id);
            return View(contact);
        }

        // POST: Contact/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var contact = ContactController.contacts.First(x => x.Id == id);
                ContactController.contacts.Remove(contact);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}