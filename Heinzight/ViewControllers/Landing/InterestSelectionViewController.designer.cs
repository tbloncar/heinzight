// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace Heinzight
{
	[Register ("InterestSelectionViewController")]
	partial class InterestSelectionViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIScrollView interestsScrollView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton startTourButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (interestsScrollView != null) {
				interestsScrollView.Dispose ();
				interestsScrollView = null;
			}

			if (startTourButton != null) {
				startTourButton.Dispose ();
				startTourButton = null;
			}
		}
	}
}
