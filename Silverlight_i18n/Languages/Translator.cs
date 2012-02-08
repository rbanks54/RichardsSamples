using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;

namespace Languages
{
	public class Translator
	{
		static ResourceManager resourceManager = new ResourceManager("Languages.ApplicationStrings", Assembly.GetExecutingAssembly());

		public static string GetString(string key)
		{
			var theString = resourceManager.GetString(key, new CultureInfo("fr-FR"));
			return theString;
		}
		private static ApplicationStrings appStrings = new ApplicationStrings();
		public static ApplicationStrings ApplicationStrings { get { return appStrings; } }
	}
}
