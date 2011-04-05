using System;

namespace WindowsFormsHost
{
	public class OpenFormRequestedArgs
	{
		public OpenFormRequestedArgs(string formName, object[] parameters)
		{
			FormName = formName;
			this.parameters = parameters;
		}

		private readonly object[] parameters;
		public object[] Parameters
		{
			get { return parameters; }
		}

		public string FormName { get; set; }
	}
}