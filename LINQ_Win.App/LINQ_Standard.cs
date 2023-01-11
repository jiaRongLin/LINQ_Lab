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
	public partial class LINQ_Standard : Form
	{
		public LINQ_Standard()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			NorthwindDataset dsNorthwind = new NorthwindDataset();
			EmployeesTableAdapter EmpTA = new EmployeesTableAdapter();
			EmpTA.Fill(dsNorthwind.Employees);

			var qEmp = from emp in dsNorthwind.Employees
					   where emp.Country == "USA"
					   select emp;

			dataGridView1.DataSource = qEmp.AsDataView();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			NorthwindDataset dsNorthwind = new NorthwindDataset();
			CategoriesTableAdapter CaTa = new CategoriesTableAdapter();
			CaTa.Fill(dsNorthwind.Categories);

			var qCa = from Ca in dsNorthwind.Categories
					  select Ca;

			dataGridView1.DataSource = qCa.AsDataView();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			var emp = new
			{
				Name ="李知恩",
				City = "高雄"
			};

			MessageBox.Show(emp.Name + " "+ emp.City);
		}

		private void button4_Click(object sender, EventArgs e)
		{
			NorthwindDataset daNor = new NorthwindDataset();
			EmployeesTableAdapter EmpTA = new EmployeesTableAdapter();
			EmpTA.Fill(daNor.Employees);

			var qEmp = from emp in daNor.Employees
					   where emp.Country == "USA"
					   select new
					   {
						   Name = emp.FirstName +" "+emp.LastName,
						   emp.City
					   };

			dataGridView1.DataSource = qEmp.ToList(); //有null值無法呈現
		}
	}
}
