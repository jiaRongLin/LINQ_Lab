using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LINQ_Win.App
{
	public partial class EntityFramework : Form
	{
		public EntityFramework()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			NorthwindEntities dbContext = new NorthwindEntities();

			//var qEmp = from emp in dbContext.Employees
			//							 where emp.Country == "USA"
			//							 select new
			//							 {
			//								 Name = emp.FirstName +" "+emp.LastName,
			//								 emp.Country
			//							 };

			IQueryable<Employees> qEmp = from emp in dbContext.Employees
										 where emp.Country == "USA"
										 select emp;

			dataGridView1.DataSource = qEmp.ToList();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			NorthwindEntities NorEn = new NorthwindEntities();

			Categories Cate = new Categories();
			Cate.CategoryName = textBoxName.Text;
			Cate.Description = textBoxDes.Text;

			NorEn.Categories.Add(Cate);

			////Categories cate = new Categories();
			////cate.CategoryName = "Beer";
			////cate.Description = "All You Need Is Drink.";

			////NorEn.Categories.Add(cate);

			//NorEn.Categories.Add(new Categories
			//{
			//	CategoryName = "Drink",
			//	Description = "DDDDRINK"
			//});
			NorEn.SaveChanges();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			NorthwindEntities NorEn = new NorthwindEntities();

			var qCate = from cate in NorEn.Categories
						select cate;

			dataGridView1.DataSource = qCate.ToList();
		}
	}
}
