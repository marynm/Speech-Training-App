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
			//Toast.MakeText (this, args.Position.ToString (), ToastLength.Short).Show ();
			gallery.ItemClick += delegate (object sender, Android.Widget.AdapterView.ItemClickEventArgs args) {
				if(args.Position == 0)
					_player = MediaPlayer.Create(this, Resource.Raw.F1mother);
				else if(args.Position == 1)
					_player = MediaPlayer.Create(this, Resource.Raw.F2numb);
				else if(args.Position == 2)
					_player = MediaPlayer.Create(this, Resource.Raw.F3horse);
				else if(args.Position == 3)
					_player = MediaPlayer.Create(this, Resource.Raw.F4scold);

				_player.Start ();

			};

		}
	}
}