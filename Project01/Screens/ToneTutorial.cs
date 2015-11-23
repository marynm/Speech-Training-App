using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics;
using Android.Media;

using System.Collections.Generic;


namespace Project01.Screens
{
	[Activity (Label = "Project")]
	public class ToneTutorial : Activity
	{
		MediaPlayer _player;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.ToneTutorial01);

			// Get our UI controls from the loaded layout:
			Button backButton = FindViewById<Button>(Resource.Id.back);


			if(backButton != null) {
				backButton.Click += (sender, e) => {
					StartActivity(typeof(WordListScreen));
				};
			}

			Gallery gallery = (Gallery) FindViewById<Gallery>(Resource.Id.tutorial_gallery);

			gallery.Adapter = new ImageAdapter (this);

			gallery.ItemClick += delegate (object sender, Android.Widget.AdapterView.ItemClickEventArgs args) {
				//Toast.MakeText (this, args.Position.ToString (), ToastLength.Short).Show ();
				_player = MediaPlayer.Create(this, Resource.Raw.forget);
				_player.Start ();


			};

		}
	}
}