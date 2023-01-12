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
	public partial class 群組 : Form
	{
		public 群組()
		{
			InitializeComponent();
		}
		NorthwindEntities Nordb = new NorthwindEntities();
		private void button1_Click(object sender, EventArgs e)
		{
			var qEmp = from emp in Nordb.Employees
					   group emp by emp.Country into E
					   select new { 國家 = E.Key, 人數 = E.Count() };

			dataGridView1.DataSource = qEmp.ToList();
			
		}

		private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			string Country = dataGridView1.CurrentRow.Cells[0].Value.ToString();

			var qEmp = from emp in Nordb.Employees
					   where emp.Country ==Country
					   select emp;

			dataGridView2.DataSource = qEmp.ToList();

		}
	}
}
