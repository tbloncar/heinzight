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
	[Register ("DetailsViewController")]
	partial class DetailsViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIWebView exhibitView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (exhibitView != null) {
				exhibitView.Dispose ();
				exhibitView = null;
			}
		}
	}
}
