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
	[Register ("DisplayListTableViewCell")]
	partial class DisplayListTableViewCell
	{
		[Outlet]
		MonoTouch.UIKit.UIImageView displayImageView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel displayLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel exhibitLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (displayImageView != null) {
				displayImageView.Dispose ();
				displayImageView = null;
			}

			if (displayLabel != null) {
				displayLabel.Dispose ();
				displayLabel = null;
			}

			if (exhibitLabel != null) {
				exhibitLabel.Dispose ();
				exhibitLabel = null;
			}
		}
	}
}
