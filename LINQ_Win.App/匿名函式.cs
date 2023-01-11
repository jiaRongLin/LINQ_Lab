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
	public partial class 匿名函式 : Form
	{
		public 匿名函式()
		{
			InitializeComponent();
		}
		delegate double Payment(double Amount);
		
		private void buttonDelegate_Click(object sender, EventArgs e)
		{
			Payment pay;
			if(comboBox1.Text == "50%off")
			{
				//pay =delegate(double Amount) { return Amount*0.5; }; 
				//pay = (double Amount) => {return Amount * 0.5;};  LambdaA
				pay = (double Amount) => Amount * 0.5;   //LambdaB
			}
			else
			{
				//pay = delegate (double Amount) { return Amount * 0.8; };
				pay = Amount => Amount * 0.8; //LambdaC
			}

			double amount = double.Parse(textBox2.Text);

			double price = pay(amount);

			MessageBox.Show("折扣後金額 " + price);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			flowLayoutPanel1.Controls.Clear();
			bool isNum = int.TryParse(textBox1.Text,out int num);
			if(!isNum) MessageBox.Show("輸入錯誤");
			for(int i = 1; i <= num; i++)
			{
				Button btn = new Button();
				btn.Text = i.ToString();
				btn.Name = $"btn{i}";
				btn.Width = 70;
				btn.Height = 50;

				btn.Click += delegate (object Sender, EventArgs E)
				{
					MessageBox.Show("這是第" + btn.Text + "個按鈕");
				};
				
				flowLayoutPanel1.Controls.Add(btn);
			}
		}
	}
}
