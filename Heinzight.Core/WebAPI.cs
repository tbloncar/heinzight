using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace Heinzight.Core
{
	public class WebAPI
	{
		private static WebAPI instance;

		private WebAPI () {}

		public static UIImage ImageFromUrl (string uri)
		{
			using (var url = new NSUrl (uri))
			using (var data = NSData.FromUrl (url))
				return UIImage.LoadFromData (data);
		}

		public string BaseURL {
			get {
				return "http://heinzight.herokuapp.com/api/";
			}
		}

		public string Token {
			get {
				return "WEARETHECHAMPIONSMYFRIEND";
			}
		}

		public static WebAPI Instance
		{
			get
			{
				if(instance == null) {
					instance = new WebAPI ();
				}

				return instance;
			}
		}
	}
}