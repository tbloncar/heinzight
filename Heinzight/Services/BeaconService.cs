using System.Collections.Generic;

using MonoTouch.Foundation;
using MonoTouch.CoreLocation;
using Heinzight.Core;

namespace Heinzight
{
	public class BeaconService
	{
		static readonly string uuid = "11111111-2222-3333-4444-555555555555";
		static readonly string rangeId = "com.heinzight.heinz";

		readonly CLLocationManager locationMgr;
		readonly CLBeaconRegion beaconRegion;

		public BeaconService()
		{
			var monkeyUUID = new NSUuid (uuid);
			beaconRegion = new CLBeaconRegion (monkeyUUID, rangeId);
			locationMgr = new CLLocationManager ();
		}

		public void StartService ()
		{
			beaconRegion.NotifyEntryStateOnDisplay = true;
			beaconRegion.NotifyOnEntry = true;
			beaconRegion.NotifyOnExit = true;

			locationMgr.DidRangeBeacons += (object sender, CLRegionBeaconsRangedEventArgs e) => {
				if (e.Beacons.Length > 0) {
					var beaconList = new List<Beacon>();
					
					foreach (var beacon in e.Beacons) {
						beaconList.Add(new Beacon {
							BeaconUUID = uuid,
							BeaconMajorNum = beacon.Major.IntValue,
							BeaconMinorNum = beacon.Minor.IntValue,
							Proximity = Beacon.CLProximityToIBeaconProximity(beacon.Proximity)
						});
					}
					BeaconManager.Instance.UpdateBeacons(beaconList);
				}
			};

			locationMgr.StartMonitoring (beaconRegion);
			locationMgr.StartRangingBeacons (beaconRegion);
		}

		public void StopMonitoring() {
			locationMgr.StopMonitoring (beaconRegion);
			locationMgr.StopRangingBeacons (beaconRegion);
		}
	}
}
