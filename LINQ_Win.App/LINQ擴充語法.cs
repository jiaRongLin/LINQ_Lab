using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LINQ_Win.App
{
	public partial class LINQ擴充語法 : Form
	{
		public LINQ擴充語法()
		{
			InitializeComponent();

			this.Load += LINQ擴充語法_Load;
		}

		

		NorthwindEntities Nordb = new NorthwindEntities();
		private void button1_Click(object sender, EventArgs e)
		{
			var q = Nordb.Employees.Where<Employees>(c => c.Country == "USA");
				//.Select(emp => emp); 不加select也可以選取全部

			dataGridView1.DataSource = q.ToList();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			var q = Nordb.Employees.GroupBy(c=>c.Country)
				.Select(emp => new {國家=emp.Key,人數=emp.Count()});

			dataGridView1.DataSource = q.ToList();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			var q = Nordb.Products.Join(Nordb.Categories, p => p.CategoryID, c => c.CategoryID, (p, c) => new
			{
				p.ProductName,
				c.CategoryName,
				p.UnitPrice
			});

			dataGridView1.DataSource = q.ToList();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			var q = Nordb.Products.GroupBy(p => p.Categories.CategoryName) //導覽屬性
				.Select(pr=>new {pr.Key,數量=pr.Count()});

			dataGridView1.DataSource = q.ToList();
		}

		private void button5_Click(object sender, EventArgs e)
		{
			var q = Nordb.Products.Join(Nordb.Categories, p => p.CategoryID, c => c.CategoryID, (p, c) => new
			{
				p.ProductName,
				c.CategoryName,
				p.UnitPrice
			}).OrderBy(ca => ca.CategoryName);

			dataGridView1.DataSource = q.ToList();
		}

		private void button6_Click(object sender, EventArgs e)
		{
			var q = Nordb.Products.Join(Nordb.Categories, p => p.CategoryID, c => c.CategoryID, (p, c) => new
			{
				p.ProductName,
				c.CategoryName,
				p.UnitPrice
			}).OrderBy(ca => ca.CategoryName).ThenByDescending(pr => pr.ProductName);

			dataGridView1.DataSource = q.ToList();
		}
		public class Student
		{
			public string StudentName { get; set; }
			public List<Course> Course { get; set; }
		}
		public class Course
		{
			public string CourseName { get; set; }
			public Course (string Name)
			{
				CourseName = Name;
			}
		}

		Student st1 = new Student
		{
			StudentName = "QQQ",
			Course =new List<Course>
			{
				new Course("ENG"),
				new Course("CHI")
			}
		};

		Student st2 = new Student
		{
			StudentName = "EEE",
			Course = new List<Course>
			{
				new Course("Math"),
				new Course("ENG"),
				new Course("CHI")
			}
		};
		private void button7_Click(object sender, EventArgs e)
		{
			string result = string.Empty;

			List<Student> StSum = new List<Student> { st1,st2};

			var q = StSum.SelectMany(stu => stu.Course, (stu, cou) => new
			{
				stu.StudentName,
				cou.CourseName,
			});

			foreach (var item in q)
			{
				result += $"{item.StudentName}{item.CourseName}\n";
			}
			MessageBox.Show(result);
		}

		private void button8_Click(object sender, EventArgs e)
		{

			var q = Nordb.Categories
				.SelectMany(c => c.Products, (c, p) => new 
				{
					c.CategoryName,
					p.ProductName,
				});

			dataGridView1.DataSource = q.ToList();
		}
		private void LINQ擴充語法_Load(object sender, EventArgs e)
		{
			foreach (var item in Nordb.Categories)
			{
				comboBox1.Items.Add(item.CategoryName);
			}
			comboBox1.SelectedIndex = 0;

		}
		private void button9_Click(object sender, EventArgs e)
		{
			//var q = Nordb.Categories.Where(c=>c.CategoryName ==comboBox1.Text);
			int Id = Nordb.Categories.First(c => c.CategoryName == comboBox1.Text).CategoryID;

			var qPro = Nordb.Products.Where(p => p.CategoryID == Id);

			dataGridView1.DataSource = qPro.ToList();
			if (qPro.Any())
			{
				var qFirst = qPro.FirstOrDefault();
				MessageBox.Show($"第一筆商品:{qFirst.ProductName}");
			}
			else MessageBox.Show("沒有資料");


			//if (qFirst != null) MessageBox.Show($"第一筆商品:{qFirst.ProductName}");
			//else MessageBox.Show("沒有資料");

		}

		private void button10_Click(object sender, EventArgs e)
		{
			if (Nordb.Categories.All(c => c.CategoryName.Length > 1))
			{
				MessageBox.Show("種類名稱全部長度大於1個字");
			}
			else
			{
				MessageBox.Show("有些種類名稱長度小於或等於1個字");
			}
		}

		private void button11_Click(object sender, EventArgs e)
		{
			//if (Nordb.Categories.All(c => c.Picture !=null))
			//{
			//	MessageBox.Show("所有種類都有圖片");
			//}
			//else
			//{
			//	MessageBox.Show("有些種類沒有圖片");
			//}

			if (Nordb.Categories.Any(c => c.Picture == null))
			{
				MessageBox.Show("有些種類沒有圖片");
			}
			else
			{
				MessageBox.Show("所有種類都有圖片");
			}
		}
	}
}
