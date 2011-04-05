using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Browser;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace HostedSilverlightPOC
{
	public partial class MainPage : UserControl
	{
		public MainPage()
		{
			InitializeComponent();
		}

		public void SetTextBoxValue(string value)
		{
			textBox1.Text = value;
		}

		private void button1_Click(object sender, RoutedEventArgs e)
		{
			NavigationControl.AskHostForForm("Page 3", textBox1.Text, "3");
		}
	}
}
