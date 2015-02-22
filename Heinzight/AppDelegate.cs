using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Heinzight
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		private UIWindow _window;
		public override UIWindow Window {
			get;
			set;
		}

		public override void FinishedLaunching (UIApplication application)
		{
			Bootstrapper.Initialize ();

			if (_window == null)
				_window = new UIWindow (UIScreen.MainScreen.Bounds);
			_window.RootViewController = new LandingNavigationController ();
			_window.MakeKeyAndVisible ();
		}

		public override bool WillFinishLaunching (UIApplication application, NSDictionary launchOptions)
		{
			if (_window == null)
				_window = new UIWindow (UIScreen.MainScreen.Bounds);
//			RectangleF bounds = UIScreen.MainScreen.Bounds;
			_window.Frame = UIScreen.MainScreen.Bounds;
			_window.Bounds = UIScreen.MainScreen.Bounds;

			return true;
		}
		
		// This method is invoked when the application is about to move from active to inactive state.
		// OpenGL applications should use this method to pause.
		public override void OnResignActivation (UIApplication application)
		{
		}
		
		// This method should be used to release shared resources and it should store the application state.
		// If your application supports background exection this method is called instead of WillTerminate
		// when the user quits.
		public override void DidEnterBackground (UIApplication application)
		{
		}
		
		// This method is called as part of the transiton from background to active state.
		public override void WillEnterForeground (UIApplication application)
		{
		}
		
		// This method is called when the application is about to terminate. Save data, if needed.
		public override void WillTerminate (UIApplication application)
		{
		}
	}
}

