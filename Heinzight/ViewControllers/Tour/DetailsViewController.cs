using System;
using System.IO;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using Heinzight.Core;
using Heinzight.Core.ORM;

namespace Heinzight
{
	public partial class DetailsViewController : UIViewController
	{
		string exhibitContent;

		public DetailsViewController (Display display) : base ("DetailsViewController", null)
		{
			exhibitContent = "";

			if (CurrentUser.Instance.Age == CurrentUser.AgeOptions.Child) {
				exhibitContent = display.ChildContent;
			} else if (CurrentUser.Instance.Age == CurrentUser.AgeOptions.Adult) {
				exhibitContent = display.AdultContent;
			}
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// Perform any additional setup after loading the view, typically from a nib.
			exhibitView.LoadHtmlString (exhibitContent,null);

		}
	}
}
