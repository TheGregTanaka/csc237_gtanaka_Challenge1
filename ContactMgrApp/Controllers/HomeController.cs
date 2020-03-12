using ContactMgrApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactMgrApp.Controllers
{
	public class HomeController : Controller
	{
		private ContactContext context { get; set; }

        public HomeController(ContactContext ctx)
		{
			context = ctx;
        }

		public IActionResult Index(int id)
		{
			var contacts = context.Contacts
				.Include(c => c.Category)
				.OrderBy(c => c.FirstName).ToList();

			return View(contacts);
		}
	}
}
