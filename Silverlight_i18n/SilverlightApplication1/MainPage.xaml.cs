using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Resources;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Languages;

namespace SilverlightApplication1
{
	public partial class MainPage : UserControl
	{
		public MyDataModel Model { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1804:RemoveUnusedLocals", MessageId = "theString2"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1804:RemoveUnusedLocals", MessageId = "theString")]
		public MainPage()
		{
			InitializeComponent();
			Model = new MyDataModel();
			DataContext = Model;
			var theString = Languages.Translator.GetString("ButtonText");
			var theString2 = Languages.Translator.GetString("SoExciting");
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Model.StringValue = ApplicationStrings.New_Text_Value;
		}

		#region No Code Here
		//Of course
		#endregion
	}

	public class MyDataModel : INotifyPropertyChanged
	{
		private string stringValue;
		public string StringValue
		{
			get { return stringValue; }
			set
			{
				stringValue = value;
				RaisePropertyChanged("StringValue");
			}
		}

		private void RaisePropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}

		public MyDataModel()
		{
			StringValue = "A new data value";
		}

		public event PropertyChangedEventHandler PropertyChanged;

	}
}
