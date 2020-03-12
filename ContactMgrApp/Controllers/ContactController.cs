using ContactMgrApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactMgrApp.Controllers
{
	public class ContactController : Controller
	{
		private ContactContext context;

		public ContactController(ContactContext ctx)
		{
			context = ctx;
		}

		public IActionResult Details(int id)
		{
			var contact = context.Contacts
				.Include(c => c.Category)
				.FirstOrDefault(c => c.ContactID == id);

			return View(contact);
		}

		[HttpGet]
		public IActionResult Add()
		{
			ViewBag.Action = "Add";
			ViewBag.Categories = context.Categories.OrderBy(c => c.Name).ToList();

			return View("Edit", new Contact());
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			ViewBag.Action = "Edit";
			ViewBag.Categories = context.Categories.OrderBy(c => c.Name).ToList();

			var contact = context.Contacts
				.Include(c => c.Category)
				.FirstOrDefault(c => c.ContactID == id);

			return View(contact);
		}

		[HttpPost]
		public IActionResult Edit(Contact contact)
		{
			string action = (contact.ContactID == 0) ? "Add" : "Edit";

			if (ModelState.IsValid)
			{
				if (action == "Add")
				{
					contact.DateAdded = DateTime.Now;
					context.Contacts.Add(contact);
				}
				else
				{
					context.Contacts.Update(contact);
				}
				context.SaveChanges();

				return RedirectToAction("Index", "Home");
			}
			else
			{
				ViewBag.Action = action;
				ViewBag.Categories = context.Categories.OrderBy(c => c.CategoryID).ToList();
			}
			return View(contact);
		}

		[HttpGet]
		public IActionResult Delete(int id)
		{
			var contact = context.Contacts
				.Include(c => c.Category)
				.FirstOrDefault(c => c.ContactID == id);

			return View(contact);
		}
		[HttpPost]
		public IActionResult Delete(Contact contact)
		{
			context.Contacts.Remove(contact);
			context.SaveChanges();
			return RedirectToAction("Index", "Home");
		}
	}
}
