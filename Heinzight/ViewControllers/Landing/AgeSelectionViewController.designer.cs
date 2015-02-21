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
	[Register ("AgeSelectionViewController")]
	partial class AgeSelectionViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIView adultView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIView adultViewButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel introTextLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIView littleKidView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIView littleKidViewButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel questionLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (adultView != null) {
				adultView.Dispose ();
				adultView = null;
			}

			if (adultViewButton != null) {
				adultViewButton.Dispose ();
				adultViewButton = null;
			}

			if (littleKidView != null) {
				littleKidView.Dispose ();
				littleKidView = null;
			}

			if (littleKidViewButton != null) {
				littleKidViewButton.Dispose ();
				littleKidViewButton = null;
			}

			if (introTextLabel != null) {
				introTextLabel.Dispose ();
				introTextLabel = null;
			}

			if (questionLabel != null) {
				questionLabel.Dispose ();
				questionLabel = null;
			}
		}
	}
}
