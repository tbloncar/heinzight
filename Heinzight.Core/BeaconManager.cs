using System;
using System.Collections.Generic;

namespace Heinzight.Core
{

	public delegate void BeaconsUpdated(List<Beacon> beaconList);

	public class BeaconManager
	{
		static BeaconManager instance;

		BeaconManager() {}

		public static BeaconManager Instance
		{
			get
			{
				if(instance == null) 
				{
					instance = new BeaconManager ();
				}
				return instance;
			}
		}

		public event BeaconsUpdated BeaconsUpdated;

		public void UpdateBeacons(List<Beacon> beacons)
		{
			BeaconsUpdated(beacons);
		}
	}
}