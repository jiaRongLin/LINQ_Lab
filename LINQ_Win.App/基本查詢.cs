using LINQ_Win.App.NorthwindDatasetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace LINQ_Win.App
{
	public partial class 基本查詢 : Form
	{
		public 基本查詢()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			NorthwindDataset NorthDs = new NorthwindDataset();
			CategoriesTableAdapter CaTa =new CategoriesTableAdapter();
			CaTa.Fill(NorthDs.Categories);

			var qCa = from ca in NorthDs.Categories
					  select ca.CategoryName into C
					  from intoCa in C
					  select intoCa;

			//dataGridView1.DataSource = qCa.ToList();
			string result = string.Empty;
			foreach(var item in qCa)
			{
				result += item + "\n";
			}
			MessageBox.Show(result);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			NorthwindDataset NorthDs = new NorthwindDataset();
			EmployeesTableAdapter EmpTa = new EmployeesTableAdapter();
			EmpTa.Fill(NorthDs.Employees);

			var qEmp = from emp in NorthDs.Employees
					   group emp by emp.Country into gEmp
					   select new { country = gEmp.Key, count = gEmp.Count()};

			dataGridView1.DataSource = qEmp.ToList();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			NorthwindDataset NorthDs = new NorthwindDataset();
			EmployeesTableAdapter EmpTa = new EmployeesTableAdapter();
			EmpTa.Fill(NorthDs.Employees);

			var qEmp = from emp in NorthDs.Employees
					   where emp.Country == "USA"
					   select new NewEmployeeSelect
					   {
						   Name = emp.FirstName + " " + emp.LastName,
						   City = emp.City+","+emp.Country,
						   Age = DateTime.Now.Year - emp.BirthDate.Year
					   };

			dataGridView1.DataSource=qEmp.ToList();
		}


		private void button4_Click(object sender, EventArgs e)
		{
			int[] arrayNum = Num(0,9);

			var qNum = from num in arrayNum
					   where num % 2 == 0
					   select new
					   {
						   偶數 = num.ToString(),
					   };

			dataGridView1.DataSource = qNum.ToList();
		}

		private void button5_Click(object sender, EventArgs e)
		{
			int[] arrayNum = Num(0,9);
			//有三種寫法
			var qNum = from num in arrayNum
					   group num by GetGroupNum(num) into N
					   select new
					   {
						   key = N.Key,
						   count = N.Count()
					   };
			//var qNum = from num in arrayNum
			//		   group num by (num % 2 == 0) ? "偶數" : "奇數" into N
			//		   select new
			//		   {
			//			   key = N.Key,

			//			   count = N.Count()
			//		   };

			//var qNum = from num in arrayNum
			//		   group num by (num % 2 == 0) into N
			//		   select new
			//		   {
			//			   key = N.Key ? "偶數" : "奇數",

			//			   count = N.Count()
			//		   };

			dataGridView1.DataSource = qNum.ToList();
		}
		/// <summary>
		/// 判斷奇偶數
		/// </summary>
		/// <param name="Num"></param>
		/// <returns></returns>
		public static string GetGroupNum (int Num)
		{
			return Num % 2 == 0 ? "偶數" : "奇數";
		}
		/// <summary>
		/// 產生陣列
		/// </summary>
		/// <param name="start">開始數字</param>
		/// <param name="end">結束數字</param>
		/// <returns>return陣列</returns>
		public static int[] Num(int start, int end)
		{
			int count = end - start + 1;
			int[] arrayNum = new int[count];
			
			for (int i = 0; i < count ; i++)
			{
				arrayNum[i] = start + i;
			}

			return arrayNum;
		}
	}
}
