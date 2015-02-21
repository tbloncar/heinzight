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

			SetCircleButtonDisplay (littleKidViewButton);
			SetCircleButtonDisplay (adultViewButton);
			continueButton.Enabled = false;

			var adultTapGesture = new UITapGestureRecognizer (SelectAdult);
			adultView.AddGestureRecognizer (adultTapGesture);

			var childTapGesture = new UITapGestureRecognizer (SelectChild);
			littleKidView.AddGestureRecognizer (childTapGesture);

			continueButton.TouchUpInside += (sender, e) => NextPage();
		}

		static void SetCircleButtonDisplay(UIView v)
		{
			v.Layer.CornerRadius = 17;
			v.Layer.BorderColor = UIColor.LightGray.CGColor;
			v.BackgroundColor = UIColor.White;
			v.Layer.BorderWidth = 2.0f;
		}

		void SelectChild()
		{
			CurrentUser.Instance.Age = CurrentUser.AgeOptions.Child;
			_optionHasBeenSelected = true;
			continueButton.Enabled = true;
		}

		void SelectAdult()
		{
			CurrentUser.Instance.Age = CurrentUser.AgeOptions.Adult;
			_optionHasBeenSelected = true;
			continueButton.Enabled = true;

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

