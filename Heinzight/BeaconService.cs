using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.CoreBluetooth;
using MonoTouch.CoreLocation;
using MonoTouch.CoreFoundation;
using MonoTouch.AVFoundation;
using MonoTouch.MultipeerConnectivity;

namespace Heinzight
{
	public class BeaconService
	{
		public static string BeaconUUID = "11111111-2222-3333-4444-555555555555";
	
		public static void StartService ()
		{
			var beaconUUID = new NSUuid (BeaconUUID);

			var locationMgr = new CLLocationManager ();
			var beaconRegion = new CLBeaconRegion(beaconUUID, "Heinzight");

			beaconRegion.NotifyEntryStateOnDisplay = true;
			beaconRegion.NotifyOnEntry = true;
			beaconRegion.NotifyOnExit = true;

			locationMgr.DidRangeBeacons += (object sender, CLRegionBeaconsRangedEventArgs e) => {
				System.Console.WriteLine (e);
			};

			locationMgr.StartMonitoring (beaconRegion);
			locationMgr.StartRangingBeacons (beaconRegion);
		}
	}
}

