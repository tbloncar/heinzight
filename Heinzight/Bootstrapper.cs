using System;

using Autofac;

using Heinzight.Core;

namespace Heinzight
{
	public class Bootstrapper
	{
		public static IContainer Container;

		public static void Initialize()
		{
			var builder = new ContainerBuilder ();

			ServiceManager.Initialize (builder.Build ());
		}
	}
}

