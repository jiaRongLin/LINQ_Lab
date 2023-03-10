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
	public partial class DataSet : Form
	{
		public DataSet()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			NorthwindDataset DSnw = new NorthwindDataset();
			EmployeesTableAdapter TaEmp = new EmployeesTableAdapter();
			TaEmp.Fill(DSnw.Employees);

			//dataGridView1.DataSource = DSnw.Employees; 兩種方法都可以
			dataGridView1.DataSource = TaEmp.GetData();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			NorthwindDataset DSnw = new NorthwindDataset();
			EmployeesTableAdapter TaEmp = new EmployeesTableAdapter();
			TaEmp.FillBy(DSnw.Employees);

			dataGridView1.DataSource = DSnw.Employees;
			//dataGridView1.DataSource = TaEmp.GetDataBy(); 兩種方法都可以
		}

		private void button3_Click(object sender, EventArgs e)
		{
			NorthwindDataset DSnw = new NorthwindDataset();
			Employees1TableAdapter TaEmp = new Employees1TableAdapter();
			TaEmp.FillByUSA(DSnw.Employees1);

			dataGridView1.DataSource = DSnw.Employees1;
			//dataGridView1.DataSource = TaEmp.GetDataByUSA(); 兩種方法都可以
		}
	}
}
