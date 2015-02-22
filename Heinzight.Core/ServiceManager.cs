﻿using System;
using Autofac;

namespace Heinzight.Core
{
	public class ServiceManager
	{

		static IContainer _container;

		ServiceManager () { }

		public static IContainer Container
		{
			get 
			{
				if (_container == null) 
				{
					throw new Exception ("Hey idiot, initialize");
				}
				return _container;
			}
		}

		public static void Initialize (IContainer c)
		{
			if (_container != null)
				throw new Exception ("Don't initialize twice, gawd");
			_container = c;
		}
	}
}

