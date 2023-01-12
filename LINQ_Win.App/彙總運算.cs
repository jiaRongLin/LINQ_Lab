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
	public partial class 彙總運算 : Form
	{
		public 彙總運算()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			NorthwindDataset NorDs = new NorthwindDataset();
			ProductsTableAdapter PTa = new ProductsTableAdapter();
			PTa.Fill(NorDs.Products);

			var qPro = from pro in NorDs.Products
					   //orderby pro.CategoryID
					   group pro by pro.CategoryID into P
					   where P.Count() > 5
					   orderby P.Count() descending
					   select new 
					   {
						   Category = P.Key,
						   ProductCount = P.Count(),
						   MaxUnitPrice = P.Max(pro => pro.UnitPrice),
						   MinUnitPrice = P.Min(pro => pro.UnitPrice),
						   SumUnitPrice = P.Sum(pro => pro.UnitPrice),
						   AvgUnitPrice = P.Average(pro => pro.UnitPrice)

					   };
			//var qPro = from pro in NorDs.Products
			//			   //orderby pro.CategoryID
			//		   group pro by pro.CategoryID into P
			//		   where P.Count() > 5
			//		   orderby P.Count() descending
			//		   select new
			//		   {
			//			   Category = P.Key,
			//			   ProductCount = P.Count(),
			//			   MaxUnitPrice = (int)P.Max(pro => pro.UnitPrice),
			//			   MinUnitPrice = (int)P.Min(pro => pro.UnitPrice),
			//			   SumUnitPrice = (int)P.Sum(pro => pro.UnitPrice),
			//			   AvgUnitPrice = (int)P.Average(pro => pro.UnitPrice)

			//		   };

			dataGridView1.DataSource = qPro.ToList();

		}
	}
}
