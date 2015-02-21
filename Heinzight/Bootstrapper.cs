using System;
using System.Linq;

using Autofac;

using SQLite;

using Heinzight.Core;
using Heinzight.Core.ORM;

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

			// Setup and seed the database
			db.Setup ();
			db.Seed ();

			using (var conn = db.GetConnection ()) {
				var table = conn.Table<Interest> ();

				foreach (var s in table) {
					Console.WriteLine (s.ID + " " + s.Name);
				}
			}
		}
	}
}

