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
			EmployeesTableAdapter empTa = new EmployeesTableAdapter();
			empTa.Fill(NorthDs.Employees);

			var qEmp = from emp in NorthDs.Employees
					   group emp by emp.Country into gEmp
					   select new { country = gEmp.Key, count = gEmp.Count()};

			dataGridView1.DataSource = qEmp.ToList();
		}
	}
}
