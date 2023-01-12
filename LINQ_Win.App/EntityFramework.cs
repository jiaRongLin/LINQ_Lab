using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.AxHost;

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
		NorthwindEntities NorEn = new NorthwindEntities();
		private void button4_Click(object sender, EventArgs e)
		{
			//var qCate = from cate in NorEn.Categories
			//			where cate.CategoryName =="Beer"
			//			select cate;

			var qCate = from cate in NorEn.Categories
						select cate;

			foreach (var cc in qCate)
			{
				cc.Description += "。";

			}

			//foreach (var c in NorEn.Categories) 取得所有值
			//{
			//	c.Description += "。";

			//}

			//NorEn.SaveChanges();
			//dataGridView1.DataSource = NorEn.Categories.ToList();

			var qC = from cate in NorEn.Categories
						select cate;

			dataGridView1.DataSource = qC.ToList();
		}

		private void button5_Click(object sender, EventArgs e)
		{
			//var qCate = (from cate in NorEn.Categories
			//			 where cate.CategoryName == "QQQ"
			//			 select cate).First(); //First抓出單一資料

			Categories Cate = NorEn.Categories.First(c => c.CategoryName == "Beer");

			NorEn.Categories.Remove(Cate); //RemoveRange大範圍刪除
			NorEn.SaveChanges();  //做完CUD都要儲存

			var qC = from cate in NorEn.Categories
					 select cate;

			dataGridView1.DataSource = qC.ToList();

		}

		private void button6_Click(object sender, EventArgs e)
		{
			NorthwindEntities dbNor = new NorthwindEntities();
			var qEmp = from emp in dbNor.Employees
					   group emp by emp.Country into E
					   select new { 國家 = E.Key, 人數 = E.Count() };

			dataGridView1.DataSource = qEmp.ToList();
		}

		private void button7_Click(object sender, EventArgs e)
		{
			var qEmp = from emp in NorEn.Employees
					   select new { Name = emp.FirstName + " " + emp.LastName, City = emp.City };
			var qCus = from cus in NorEn.Customers
					   select new { Name = cus.ContactName, City = cus.City };

			dataGridView1.DataSource = qEmp.Union(qCus).ToList(); //會排除重複值

		}

		private void button8_Click(object sender, EventArgs e)
		{
			var qEmp = from emp in NorEn.Employees
					   select new { Name = emp.FirstName + " " + emp.LastName, City = emp.City };
			var qCus = from cus in NorEn.Customers
					   select new { Name = cus.ContactName, City = cus.City };

			dataGridView1.DataSource = qEmp.Concat(qCus).OrderBy(o=>o.Name).ToList(); //全部都會出現 偷偷加了orderby排序
		}

		private void button9_Click(object sender, EventArgs e)
		{
			var qJ = from c in NorEn.Categories
					 join p in NorEn.Products on c.CategoryID equals p.CategoryID
					 select new
					 {
						 ProductName = p.ProductName,
						 ProductUnitPrice = p.UnitPrice,
						 CategoryName = c.CategoryName

					 };

			dataGridView1.DataSource = qJ.ToList();
		}

		private void button10_Click(object sender, EventArgs e)
		{
			//var qLJ = from c in NorEn.Categories
			//		  join p in NorEn.Products on c.CategoryID equals p.CategoryID
			//		  into lsCP
			//		  from cp in lsCP.DefaultIfEmpty(new Products { CategoryID = -1, ProductID = -1, ProductName = "No Product" })
			//		  select new
			//		  {
			//			  c.CategoryID,
			//			  c.CategoryName,
			//		  };

			List<Contact> lsContact = new List<Contact>
			{
				new Contact{ComID = 1,ContactName = "John"},
				new Contact{ComID = 3 ,ContactName ="Jenna"},
				new Contact{ComID = 4 ,ContactName = "Winnie" }
			};

			List<Company> laCompany = new List<Company>
			{
				new Company{ComID = 1,CompanyName="APPLE"},
				new Company{ComID =2 ,CompanyName="MS"},
				new Company{ComID =3,CompanyName="AMZN"},
				new Company{ComID = 4,CompanyName = "SpaceX"}
			};

			var q = from com in laCompany
					join c in lsContact on com.ComID equals c.ComID into ls
					from c in ls.DefaultIfEmpty(new Contact { ComID =-1,ContactName="(Null)"})
					select new {com.ComID,com.CompanyName,c.ContactName};


			dataGridView1.DataSource = q.ToList();                       
		}

		private void button11_Click(object sender, EventArgs e)
		{
			var q = from Pro in NorEn.Products
					select new
					{
						ProductName = Pro.ProductName,
						ProductUnitPrice = Pro.UnitPrice,
						CategoryName = Pro.Categories.CategoryName //導覽屬性 跟join結果依
					};

			dataGridView1.DataSource = q.ToList();
		}

		private void button12_Click(object sender, EventArgs e)
		{
			var q = from cate in NorEn.Categories
					from p in cate.Products
					orderby p.CategoryID
					select new
					{
						p.CategoryID,
						p.ProductName,
						p.UnitPrice,
						cate.CategoryName,
						cate.Picture
					};

			//var q1 = from p in NorEn.Products
			//		from c in p.Categories
			//		orderby c.CategoryID
			//		select new
			//		{
			//			c.CategoryID,
			//			p.ProductName,
			//			p.UnitPrice,
			//			c.CategoryName,
			//			c.Picture
			//		};

			dataGridView1.DataSource = q.ToList();
		}
	}
}
