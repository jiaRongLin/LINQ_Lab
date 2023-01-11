using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LINQ_Win.App
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void btnQuery_Click(object sender, EventArgs e)
		{
			string conn = "Data Source = . ;initial catalog = Northwind ;integrated security = true;";
			string cmd = $@"
SELECT [FirstName] +　' ' +[LastName] as Name,[City]
FROM Employees
WHERE [Country]='USA'";

			SqlConnection sqlconn = new SqlConnection(conn);
			SqlCommand sqlcmd = new SqlCommand(cmd, sqlconn);
			sqlcmd.CommandType = CommandType.Text;

			sqlconn.Open();

			DataTable data = new DataTable();
			data.Load(sqlcmd.ExecuteReader());


			dataGridView1.DataSource = data;

			sqlcmd.Dispose();
			sqlconn.Close();
			sqlconn.Dispose();
		}
	}
}
