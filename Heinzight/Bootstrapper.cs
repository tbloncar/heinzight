using System;
using System.Linq;

using SQLiteNetExtensions.Extensions;

using Heinzight.Core;
using Heinzight.Core.ORM;

namespace Heinzight
{
	public class Bootstrapper
	{
		public static void Initialize()
		{
			var db = Db.Instance;

			// Setup and seed the database
			db.Setup ();
			db.Seed ();

			// Log to prove we've saved somethin'
			using (var conn = db.GetConnection ()) {
				var displayInterests = conn.GetAllWithChildren <DisplayInterest> ().ToList();

				foreach (var di in displayInterests) {
					Console.WriteLine (di.Interest.Name + " " + di.Display.Name);
				} 
			}
		}
	}
}

