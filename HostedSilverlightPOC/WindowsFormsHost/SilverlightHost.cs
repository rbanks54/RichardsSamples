using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsHost
{
	[ComVisible(true)]
	public partial class SilverlightHost : UserControl
	{
		public event OpenFormRequestedHandler OpenFormRequested;

		public SilverlightHost()
		{
			InitializeComponent();
			webBrowser1.AllowNavigation = false;
			webBrowser1.AllowWebBrowserDrop = false;
			webBrowser1.IsWebBrowserContextMenuEnabled = false;
			webBrowser1.WebBrowserShortcutsEnabled = false;
			webBrowser1.DocumentCompleted += (s, e) => documentLoaded = true;
			webBrowser1.ObjectForScripting = this;
		}

		public void LoadSilverlightFrom(string url)
		{
			NavigateToUrl(url);
		}

		private bool documentLoaded = false;

		private void NavigateToUrl(string url)
		{
			documentLoaded = false;
			webBrowser1.Navigate(url);
		}

		public void ShowForm(string formName, object[] parameters)
		{
			while (!documentLoaded)
				Application.DoEvents();
			var args = new List<object> {formName};
			if (parameters != null)
				args.AddRange(parameters);
			webBrowser1.Document.InvokeScript("ShowForm", args.ToArray());
		}

		public void AskHostToOpenForm(string formName, string p1, string p2, string p3)
		{
			var args = new OpenFormRequestedArgs(formName, new object[] {p1, p2, p3});
			if (OpenFormRequested != null)
			{
				OpenFormRequested(this, args);
			}
		}
	}

	public delegate void OpenFormRequestedHandler(object sender, OpenFormRequestedArgs args);
}


