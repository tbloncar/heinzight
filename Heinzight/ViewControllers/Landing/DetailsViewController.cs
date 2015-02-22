
using System;
using System.IO;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Heinzight
{
	public partial class DetailsViewController : UIViewController
	{
		public DetailsViewController () : base ("DetailsViewController", null)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			var exhibitContent = File.ReadAllText ("");
			
			// Perform any additional setup after loading the view, typically from a nib.

			exhibitView.LoadHtmlString(exhibitContent,null);
		}
	}
}

