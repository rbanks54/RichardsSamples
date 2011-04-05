using System;
using System.Collections.Generic;
using System.Diagnostics;
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
	public partial class NavigationControl : UserControl
	{
		public NavigationControl()
		{
			InitializeComponent();
			HtmlPage.RegisterScriptableObject("Page", this);

			pageLaunchers.Add("Main", (p) =>
			{
				var mp = new MainPage();
				mp.textBox1.Text = (string)p[0];
				return mp;
			});
			pageLaunchers.Add("Page 3", p =>
			{
				var p3 = new Page3();
				try
				{
					p3.textBox1.Text = (string)p[0];
					p3.textBox2.Text = (string)p[1];
				}
				catch
				{
					//naughty swallow here
				}
				return p3;
			});
			pageLaunchers.Add("AnotherOne", p =>
			{
				var page = new AnotherOne();
				return page;
			});
		}

		private readonly Dictionary<string, Func<IList<object>, UserControl>> pageLaunchers = new Dictionary<string, Func<IList<object>, UserControl>>();

		[ScriptableMember]
		public void NavigateTo(string controlName, ScriptObject parameterList)
		{
			var paramList = parameterList.ConvertTo<List<object>>();
			var launcher = pageLaunchers[controlName];
			LayoutRoot.Children.Clear();
			var form = launcher(paramList);
			LayoutRoot.Children.Add(form);
		}

		public static void AskHostForForm(string formName, string p1 = "", string p2 = "", string p3 = "")
		{
			var form = (ScriptObject)HtmlPage.Window.GetProperty("external");
			form.Invoke("AskHostToOpenForm", formName, p1, p2, p3);
		}
	}
}
