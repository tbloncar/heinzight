using System;
using MonoTouch;
using MonoTouch.UIKit;

namespace Heinzight
{
	public class LandingNavigationController : UINavigationController
	{
		public LandingNavigationController ()
		{
			PushViewController (new LandingViewController(), false);
			NavigationBarHidden = true;
		}
	}
}

