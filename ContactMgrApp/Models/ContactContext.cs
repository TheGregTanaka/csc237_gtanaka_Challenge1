using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactMgrApp.Models
{
	public class ContactContext : DbContext
	{
		public ContactContext(DbContextOptions<ContactContext> options)
			: base(options)
		{ }

		public DbSet<Category> Categories { get; set; }
		public DbSet<Contact> Contacts { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Category>().HasData(
				new Category { CategoryID = 1, Name = "Family" },
				new Category { CategoryID = 2, Name = "Friend" },
				new Category { CategoryID = 3, Name = "Work" },
				new Category { CategoryID = 4, Name = "Other" }
				);

			modelBuilder.Entity<Contact>().HasData(
				new Contact
				{
					ContactID = 1,
					FirstName = "Marry Ellen",
					LastName = "Walton",
					Phone = "555-123-1234",
					Email = "marryellen@yahoo.com",
					CategoryID = 1,
					DateAdded = DateTime.Now
				},
				new Contact
				{
					ContactID = 2,
					FirstName = "Delores",
					LastName = "Del Rio",
					Phone = "555-987-6543",
					Email = "delores@yahoo.com",
					CategoryID = 2,
					DateAdded = DateTime.Now
				},
				new Contact
				{
					ContactID = 3,
					FirstName = "Efren",
					LastName = "Herrera",
					Phone = "555-111-1111",
					Email = "efren@yahoo.com",
					CategoryID = 3,
					DateAdded = DateTime.Now
				}
				);
		}
	}
}
