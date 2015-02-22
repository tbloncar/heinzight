using System;

using MonoTouch.Foundation;
using MonoTouch.CoreLocation;

namespace Heinzight
{
	public class BeaconService
	{
		static readonly string uuid = "11111111-2222-3333-4444-555555555555";
		static readonly string rangeId = "com.heinzight.heinz";

		CLLocationManager locationMgr;
		CLBeaconRegion beaconRegion;

		public void StartService ()
		{
			Console.WriteLine ("beacon service");
			var monkeyUUID = new NSUuid (uuid);
			beaconRegion = new CLBeaconRegion (monkeyUUID, rangeId);

			beaconRegion.NotifyEntryStateOnDisplay = true;
			beaconRegion.NotifyOnEntry = true;
			beaconRegion.NotifyOnExit = true;

			locationMgr = new CLLocationManager ();

			locationMgr.RequestWhenInUseAuthorization ();

			locationMgr.DidRangeBeacons += (object sender, CLRegionBeaconsRangedEventArgs e) => {
				if (e.Beacons.Length > 0) {

					CLBeacon beacon = e.Beacons [0];
					string message = "";

					switch (beacon.Proximity) {
					case CLProximity.Immediate:
						message = "You found the monkey!";
						Console.WriteLine( message);
						break;
					case CLProximity.Near:
						message = "You're getting warmer";
						break;
					case CLProximity.Far:
						message = "You're freezing cold";
						break;
					case CLProximity.Unknown:
						message = "I'm not sure how close you are to the monkey";
						break;
					}

					Console.WriteLine(message);

				}
			};

			locationMgr.StartMonitoring (beaconRegion);
			locationMgr.StartRangingBeacons (beaconRegion);
		}
	}
}
