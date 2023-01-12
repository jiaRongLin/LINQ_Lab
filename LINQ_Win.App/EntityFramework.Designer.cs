namespace LINQ_Win.App
{
	partial class EntityFramework
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.button1 = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.textBoxDes = new System.Windows.Forms.TextBox();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.button8 = new System.Windows.Forms.Button();
			this.button9 = new System.Windows.Forms.Button();
			this.button10 = new System.Windows.Forms.Button();
			this.button11 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(12, 17);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(86, 32);
			this.button1.TabIndex = 0;
			this.button1.Text = "Employee";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(154, 17);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowHeadersWidth = 51;
			this.dataGridView1.RowTemplate.Height = 27;
			this.dataGridView1.Size = new System.Drawing.Size(792, 535);
			this.dataGridView1.TabIndex = 1;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(12, 55);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(127, 32);
			this.button2.TabIndex = 2;
			this.button2.Text = "Add Categories";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(12, 149);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(127, 32);
			this.button3.TabIndex = 3;
			this.button3.Text = "Categories";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// textBoxName
			// 
			this.textBoxName.Location = new System.Drawing.Point(12, 90);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(127, 25);
			this.textBoxName.TabIndex = 4;
			// 
			// textBoxDes
			// 
			this.textBoxDes.Location = new System.Drawing.Point(12, 121);
			this.textBoxDes.Name = "textBoxDes";
			this.textBoxDes.Size = new System.Drawing.Size(127, 25);
			this.textBoxDes.TabIndex = 5;
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(12, 187);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(127, 32);
			this.button4.TabIndex = 6;
			this.button4.Text = "Update Categories";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(12, 225);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(127, 32);
			this.button5.TabIndex = 7;
			this.button5.Text = "Delete Categories";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(12, 263);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(127, 49);
			this.button6.TabIndex = 8;
			this.button6.Text = "GroupBy Categories";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(12, 318);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(127, 32);
			this.button7.TabIndex = 9;
			this.button7.Text = "Union";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new System.EventHandler(this.button7_Click);
			// 
			// button8
			// 
			this.button8.Location = new System.Drawing.Point(12, 356);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(127, 32);
			this.button8.TabIndex = 10;
			this.button8.Text = "Concat";
			this.button8.UseVisualStyleBackColor = true;
			this.button8.Click += new System.EventHandler(this.button8_Click);
			// 
			// button9
			// 
			this.button9.Location = new System.Drawing.Point(12, 394);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(127, 32);
			this.button9.TabIndex = 11;
			this.button9.Text = "Join";
			this.button9.UseVisualStyleBackColor = true;
			this.button9.Click += new System.EventHandler(this.button9_Click);
			// 
			// button10
			// 
			this.button10.Location = new System.Drawing.Point(12, 432);
			this.button10.Name = "button10";
			this.button10.Size = new System.Drawing.Size(127, 32);
			this.button10.TabIndex = 12;
			this.button10.Text = "Left outer Join";
			this.button10.UseVisualStyleBackColor = true;
			this.button10.Click += new System.EventHandler(this.button10_Click);
			// 
			// button11
			// 
			this.button11.Location = new System.Drawing.Point(12, 470);
			this.button11.Name = "button11";
			this.button11.Size = new System.Drawing.Size(127, 32);
			this.button11.TabIndex = 13;
			this.button11.Text = "導覽屬性";
			this.button11.UseVisualStyleBackColor = true;
			this.button11.Click += new System.EventHandler(this.button11_Click);
			// 
			// EntityFramework
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(958, 593);
			this.Controls.Add(this.button11);
			this.Controls.Add(this.button10);
			this.Controls.Add(this.button9);
			this.Controls.Add(this.button8);
			this.Controls.Add(this.button7);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.textBoxDes);
			this.Controls.Add(this.textBoxName);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.button1);
			this.Name = "EntityFramework";
			this.Text = "EntityFramework";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.TextBox textBoxName;
		private System.Windows.Forms.TextBox textBoxDes;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.Button button9;
		private System.Windows.Forms.Button button10;
		private System.Windows.Forms.Button button11;
	}
}