using System;
using System.Collections.Generic;
using Autofac;

namespace Heinzight.Core
{
	public class Beacon
	{
		private static Beacon instance;

		private Beacon() {}

		public static Beacon Instance
		{
			get
			{
				if(instance == null) 
				{
					instance = new Beacon ();
				}
				return instance;
			}
		}

		public string BeaconUUID { get ; set; }
		public int BeaconMajorNum { get; set; }
		public int BeaconMinorNum { get; set; }
	}
}