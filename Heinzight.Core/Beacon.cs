using System;
using MonoTouch.CoreLocation;


namespace Heinzight.Core
{
	public enum IBeaconProximity { Immediate, Near, Far, Unknown };
	public class Beacon
	{

		public string BeaconUUID { get ; set; }
		public int BeaconMajorNum { get; set; }
		public int BeaconMinorNum { get; set; }
		public IBeaconProximity Proximity { get; set; }

		public static IBeaconProximity CLProximityToIBeaconProximity(CLProximity prox)
		{
			switch (prox) {
			case CLProximity.Near:
				return IBeaconProximity.Near;
			case CLProximity.Far:
				return IBeaconProximity.Far;
			case CLProximity.Immediate:
				return IBeaconProximity.Immediate;
			case CLProximity.Unknown:
				return IBeaconProximity.Near;
			default:
				return IBeaconProximity.Near;
			}
		}
	}
}

