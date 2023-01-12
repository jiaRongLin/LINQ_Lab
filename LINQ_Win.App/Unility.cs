using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Win.App
{
	internal class NewEmployeeSelect
	{

		public string Name { get; internal set; }
		public string City { get; internal set; }
		public int Age { get; internal set; }

	}
	public class Contact
	{
		public int ComID { get; set; }
		public string ContactName { get; set; }
	}
	public class Company
	{
		public int ComID { get; set; }
		public string CompanyName { get; set; }

	}
}
