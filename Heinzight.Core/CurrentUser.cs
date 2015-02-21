using System;
using System.Collections.Generic;
using Autofac;

namespace Heinzight.Core
{
	public class CurrentUser
	{
		private static CurrentUser instance;
		public enum AgeOptions { Adult, Child };

		public static CurrentUser Instance
		{
			get 
			{
				if (instance == null)
				{
					instance = new CurrentUser();
				}
				return instance;
			}

		}
		private CurrentUser() {}
		public AgeOptions Age { get ; set; }
		public List<string> Interests { get; set; }
	}
}