
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Heinzight
{
	public partial class ExhibitCardViewController : UICollectionViewController
	{
		public ExhibitCardViewController (UICollectionViewLayout layout) : base ("ExhibitCardViewController", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();

			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// Register any custom UICollectionViewCell classes
			CollectionView.RegisterClassForCell (typeof(ExhibitCardViewCell), ExhibitCardViewCell.Key);

			// Note: If you use one of the Collection View Cell templates to create a new cell type,
			// you can register it using the RegisterNibForCell() method like this:
			//
			// CollectionView.RegisterNibForCell (MyCollectionViewCell.Nib, MyCollectionViewCell.Key);
		}

		public override int NumberOfSections (UICollectionView collectionView)
		{
			// TODO: return the actual number of sections
			return 1;
		}

		public override int GetItemsCount (UICollectionView collectionView, int section)
		{
			// TODO: return the actual number of items in the section
			return 1;
		}

		public override UICollectionViewCell GetCell (UICollectionView collectionView, NSIndexPath indexPath)
		{
			var cell = collectionView.DequeueReusableCell (ExhibitCardViewCell.Key, indexPath) as ExhibitCardViewCell;

			// TODO: populate the cell with the appropriate data based on the indexPath

			return cell;
		}
	}
}

