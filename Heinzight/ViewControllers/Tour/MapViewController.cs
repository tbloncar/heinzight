
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Heinzight
{
	public partial class MapViewController : UIViewController
	{
		public MapViewController () : base ("MapViewController", null)
		{
		}

		UIScrollView scrollView;
		UIImageView imageView;

		public override void ViewDidLoad()
		{
			base.ViewDidLoad ();

			scrollView = new UIScrollView (
				new RectangleF (0, 0, View.Frame.Width,
					View.Frame.Height));
			View.AddSubview (scrollView);

			imageView = new UIImageView (UIImage.FromBundle ("heinz-map.png"));

			scrollView.ContentSize = imageView.Image.Size;
			scrollView.AddSubview (imageView);
			scrollView.MaximumZoomScale = 0.7f;
			scrollView.MinimumZoomScale = 0.4f;
			scrollView.ContentOffset = new PointF (0, 500);
			scrollView.ZoomScale = 5f;
			scrollView.ViewForZoomingInScrollView += (UIScrollView svm) => {
				return imageView;
			};

			UITapGestureRecognizer doubletap =  new UITapGestureRecognizer(OnDoubleTap) {
				NumberOfTapsRequired = 2 // double tap
			};
			scrollView.AddGestureRecognizer(doubletap);
		}

		private void OnDoubleTap (UIGestureRecognizer gesture) {
//			PresentingViewController.DismissViewController(true, null);
		}
	}
}

