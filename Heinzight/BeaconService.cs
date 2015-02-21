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
		static readonly string uuid = "11111111-2222-3333-4444-555555555555";
		static readonly string beaconId = "1";

		public BeaconService ()
		{
			var beaconUUID = new NSUuid (uuid);
			var beaconRegion = new CLBeaconRegion (beaconUUID, beaconId);
			//power - the received signal strength indicator (RSSI) value (measured in decibels) of the beacon from one meter away
			var power = new NSNumber (-59);
		}
	}
}

