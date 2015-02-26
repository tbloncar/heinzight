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
			db.Delete ();
			db.Create ();
			db.Seed ();

			// Log to prove we've saved somethin'
			using (var conn = db.GetConnection ()) {
				var displays = conn.GetAllWithChildren <Display> ().ToList();

				foreach (var d in displays) {
					Console.WriteLine (d.AdultContentHTML);
				} 
			}
		}
	}
}

