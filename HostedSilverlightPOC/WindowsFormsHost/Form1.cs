using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsHost
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			silverlightHost1.LoadSilverlightFrom(@"http://localhost:6878/HostedSilverlightPOCTestPage.html");
			silverlightHost1.OpenFormRequested += (s, e) =>
				{
					MessageBox.Show(string.Format("Requested form {0}", e.FormName));
					silverlightHost1.ShowForm(e.FormName, e.Parameters);
				};
		}

		private void button1_Click(object sender, EventArgs e)
		{
			silverlightHost1.ShowForm("Main", new object[] { textBox1.Text });
		}

		private void button2_Click(object sender, EventArgs e)
		{
			silverlightHost1.ShowForm("AnotherOne", null);
		}

		private void button3_Click(object sender, EventArgs e)
		{
			silverlightHost1.ShowForm("Page 3", new object[] { "waahoo!", "3" });
		}
	}
}
