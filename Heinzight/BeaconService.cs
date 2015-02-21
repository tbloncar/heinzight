using System;

using MonoTouch.Foundation;
using MonoTouch.CoreLocation;

namespace Heinzight
{
	public class BeaconService
	{
		static readonly string uuid = "11111111-2222-3333-4444-555555555555";
		static readonly string beaconId = "com.heinzight.heinz";

		CLLocationManager locationManager;
		CLProximity previousProximity;
		CLBeaconRegion beaconRegion;

		string message;

		public void StartService ()
		{

			var beaconUUID = new NSUuid (uuid);
			beaconRegion = new CLBeaconRegion (beaconUUID, beaconId);
			Console.WriteLine (beaconRegion);
			beaconRegion.NotifyEntryStateOnDisplay = true;
			beaconRegion.NotifyOnEntry = true;
			beaconRegion.NotifyOnExit = true;

			locationManager = new CLLocationManager ();

			var old1 = new CLBeaconRegion (beaconUUID, "1");
			var old2 = new CLBeaconRegion (beaconUUID, "Heinzight");
			locationManager.StopMonitoring (old1);
			locationManager.StopMonitoring (old2);
//			locationManager.RequestWhenInUseAuthorization ();

			locationManager.StartMonitoring (beaconRegion);
			locationManager.StartRangingBeacons (beaconRegion);

			Console.WriteLine(locationManager.MonitoredRegions);

			locationManager.DidStartMonitoringForRegion += (object sender, CLRegionEventArgs e) => {
				Console.WriteLine ("beacon monitoring");
				locationManager.RequestState (e.Region);
			};

			locationManager.RegionEntered += (object sender, CLRegionEventArgs e) => {
				if (e.Region.Identifier == beaconId) {
					Console.WriteLine ("beacon region entered");
				}
			};

			locationManager.DidDetermineState += (object sender, CLRegionStateDeterminedEventArgs e) => {

				switch (e.State) {
				case CLRegionState.Inside:
					Console.WriteLine ("region state inside");
					break;
				case CLRegionState.Outside:
					Console.WriteLine ("region state outside");
					break;
				case CLRegionState.Unknown:
				default:
					Console.WriteLine ("region state unknown");
					break;
				}
				Console.WriteLine("stat");
			};

			locationManager.DidRangeBeacons += (object sender, CLRegionBeaconsRangedEventArgs e) => {
				if (e.Beacons.Length > 0) {

					CLBeacon beacon = e.Beacons [0];

					switch (beacon.Proximity) {
					case CLProximity.Immediate:
						message = "Immediate";
						break;
					case CLProximity.Near:
						message = "Near";
						break;
					case CLProximity.Far:
						message = "Far";
						break;
					case CLProximity.Unknown:
						message = "Unknown";
						break;
					}

					if (previousProximity != beacon.Proximity) {
						Console.WriteLine (message);
					}
					previousProximity = beacon.Proximity;
				}
				Console.WriteLine("ranged");
			};
				
			Console.WriteLine("strapped");
		}
	}
}
