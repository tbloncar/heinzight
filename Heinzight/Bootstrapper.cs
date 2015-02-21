using System;

using Autofac;

using SQLite;

using Heinzight.Core;
using Heinzight.Core.Orm;

namespace Heinzight
{
	public class Bootstrapper
	{
		public static IContainer Container;

		public static void Initialize()
		{
			var builder = new ContainerBuilder ();

			ServiceManager.Initialize (builder.Build ());

			var db = Db.Instance;

			db.Delete ();
			db.Create ();
			db.Seed ();

			using (var conn = db.GetConnection ()) {
				var table = conn.Table<Location> ();
				foreach (var s in table) {
					Console.WriteLine (s.ID + " " + s.Name);
				}
			}
		}
	}
}

