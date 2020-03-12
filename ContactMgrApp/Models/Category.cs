using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactMgrApp.Models
{
	public class Category
	{
		// primary key - generate by database 
		[Key]
		public int CategoryID { get; set; }

		public string Name { get; set; }
	}
}
