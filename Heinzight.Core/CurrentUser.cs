using System;
using Autofac;

namespace Heinzight.Core
{
	public class CurrentUser
	{
		private static CurrentUser instance;

		private CurrentUser() {}

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
	}
}