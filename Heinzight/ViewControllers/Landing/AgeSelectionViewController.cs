using System;
using MonoTouch.UIKit;
using Heinzight.Core;

namespace Heinzight
{
	public partial class AgeSelectionViewController : UIViewController
	{
		bool _optionHasBeenSelected = false;

		public AgeSelectionViewController () : base ("AgeSelectionViewController", null)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			SetCircleButtonDisplay (littleKidViewButton, littleKidInnerView);
			SetCircleButtonDisplay (adultViewButton, adultInnerView);
			continueButton.Hidden = true;

			var adultTapGesture = new UITapGestureRecognizer (SelectAdult);
			adultContainerView.AddGestureRecognizer (adultTapGesture);

			var childTapGesture = new UITapGestureRecognizer (SelectChild);
			littleKidContainerView.AddGestureRecognizer (childTapGesture);

			continueButton.TouchUpInside += (sender, e) => NextPage();
		}

		static void SetCircleButtonDisplay(UIView v, UIView iv)
		{
			v.Layer.CornerRadius = 17;
			v.Layer.BorderColor = UIColor.White.CGColor;
			v.BackgroundColor = UIColor.FromWhiteAlpha(1,0);
			v.Layer.BorderWidth = 2.0f;

			iv.Layer.CornerRadius = 15;
			iv.BackgroundColor = UIColor.FromWhiteAlpha (1, 0);
		}

		void SelectChild()
		{
			CurrentUser.Instance.Age = CurrentUser.AgeOptions.Child;
			littleKidInnerView.BackgroundColor = UIColor.White;
			adultInnerView.BackgroundColor = UIColor.FromWhiteAlpha(1,0);

			littleKidIconView.Image = UIImage.FromBundle("person-selected.png");
			adultIconView.Image = UIImage.FromBundle("person.png");
			EnableContinue ();
		}

		void SelectAdult()
		{
			CurrentUser.Instance.Age = CurrentUser.AgeOptions.Adult;
			adultInnerView.BackgroundColor = UIColor.White;
			littleKidInnerView.BackgroundColor = UIColor.FromWhiteAlpha(1,0);

			adultIconView.Image = UIImage.FromBundle("person-selected.png");
			littleKidIconView.Image = UIImage.FromBundle("person.png");
			EnableContinue ();
		}

		void EnableContinue() {
			_optionHasBeenSelected = true;
			continueButton.Hidden = false;
		}

		void NextPage()
		{
			if (_optionHasBeenSelected) 
			{
				NavigationController.PushViewController (new InterestSelectionViewController (), true);
			}
		}
	}
}

