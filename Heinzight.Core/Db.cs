using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

using SQLite.Net;
using SQLiteNetExtensions.Extensions;

using RestSharp;

using Heinzight.Core.ORM;
using Heinzight.Core.Deserializers;

namespace Heinzight.Core
{
	public class Db
	{
		private static Db instance;

		private Db() {}

		public string FilePath = Path.Combine(Environment.GetFolderPath (Environment.SpecialFolder.Personal), "heinzight");

		public static Db Instance
		{
			get
			{
				if(instance == null) {
					instance = new Db ();
				}

				return instance;
			}
		}

		public SQLiteConnection GetConnection() {
			#if __IOS__
			return new SQLiteConnection (new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS(), FilePath);
			#elif __ANDROID__
			return new SQLiteConnection (new SQLite.Net.Platform.Xamarin
			#endif
		}

		public bool HasBeenCreated()
		{
			return File.Exists (FilePath);
		}

		public void Create() {
			if (HasBeenCreated ()) return;

			using (var conn = GetConnection ()) {
				conn.CreateTable<Location> ();
				conn.CreateTable<Exhibit> ();
				conn.CreateTable<Display> ();
				conn.CreateTable<Interest> ();
				conn.CreateTable<DisplayInterest> ();
				conn.CreateTable<DataSyncStatus> ();

				conn.Insert (new DataSyncStatus { Version = 0 });
			}
		}

		public void Delete()
		{
			File.Delete(FilePath);
		}

		public void Seed() {
			int syncVersion;

			using (var conn = Db.Instance.GetConnection ()) {
				syncVersion = conn.Table<DataSyncStatus> ().First ().Version;
			}
				
			var client = new RestClient (WebAPI.Instance.BaseURL);
			var request = new RestRequest ("data_syncs/sync", Method.GET);

			request.AddParameter ("token", WebAPI.Instance.Token);
			request.AddParameter ("version", syncVersion);

			var response = client.Execute<DataSyncDeserializer> (request);

			Console.WriteLine(response.Data.Version);
			Console.WriteLine(syncVersion);
			Console.WriteLine(response.StatusCode);

			if(response.Data.Data != null && response.Data.Version > syncVersion) {
				Sync(response.Data.Data, response.Data.Version);
			}
		}

		private void Sync(DataDeserializer data, int latestVersion)
		{
			var exhibits = new Dictionary<int, Exhibit> ();
			var displays = new Dictionary<int, Display> ();
			var interests = new Dictionary<int, Interest> ();

			using (var conn = GetConnection ()) {
				conn.DropTable<Location> ();
				conn.DropTable<Exhibit> ();
				conn.DropTable<Display> ();
				conn.DropTable<Interest> ();
				conn.DropTable<DisplayInterest> ();

				conn.CreateTable<Location> ();
				conn.CreateTable<Exhibit> ();
				conn.CreateTable<Display> ();
				conn.CreateTable<Interest> ();
				conn.CreateTable<DisplayInterest> ();
				conn.CreateTable<DataSyncStatus> ();

				foreach (var locationData in data.Locations) {
					var location = locationData.ToLocation ();

					location.Exhibits = new List<Exhibit> ();
					location.Displays = new List<Display> ();
					location.Interests = new List<Interest> ();

					foreach (var exhibitData in locationData.Exhibits) {
						var exhibit = exhibitData.ToExhibit ();

						exhibits.Add (exhibitData.Id, exhibit);
						location.Exhibits.Add (exhibit);
					}

					foreach (var displayData in locationData.Displays) {
						var display = displayData.ToDisplay ();

						display.Exhibit = exhibits[displayData.ExhibitId];

						displays.Add (displayData.Id, display);
						location.Displays.Add (display);
					}

					foreach (var interestData in locationData.Interests) {
						var interest = interestData.ToInterest ();

						interests.Add (interestData.Id, interest);
						location.Interests.Add (interest);
					}

					conn.InsertWithChildren (location, recursive: true);
				}
					
				foreach (var displayInterestsData in data.DisplayInterests) {
					conn.Insert (new DisplayInterest {
						Display = displays[displayInterestsData.DisplayId],
						Interest = interests[displayInterestsData.InterestId]
					});
				}

				// Update data sync status version
				var dataSyncStatus = conn.Table<DataSyncStatus> ().First ();
				dataSyncStatus.Version = latestVersion;
				conn.Update (dataSyncStatus);

				Console.WriteLine ("LATEST: {0}", dataSyncStatus.Version);
			}
		}
	}
}

