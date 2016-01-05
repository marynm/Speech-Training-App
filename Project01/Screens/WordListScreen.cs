using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics;

using SQLite;

using System.Collections.Generic;


namespace Project01.Screens
{
	[Activity (Label = "Project")]
	public class WordListScreen : Activity
	{
		IList<word> words;
		Adapters.WordListAdapter wordList;
		ListView wordListView;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set view from layout resource
			SetContentView (Resource.Layout.WordSelect);

			string dbPath = FileAccessHelper.GetLocalFilePath ("WordDatabase");
			//LoadApplication (new word.App (dbPath, new SQLitePlatformAndroid ()));

			// Get our UI controls from the loaded layout:
			Button exampleButton = FindViewById<Button>(Resource.Id.exampleMode);	//temporary button for development
			Button backButton = FindViewById<Button>(Resource.Id.back);
			Button tutorialButton = FindViewById<Button>(Resource.Id.tutorial); 
			wordListView = FindViewById<ListView> (Resource.Id.wordList);

			words = WordManager.GetWords();

			// create our adapter
			wordList = new Adapters.WordListAdapter(this, words);

			//Hook up our adapter to our ListView
			wordListView.Adapter = wordList;

			//wire up add example button handler
			if(exampleButton != null) {
					exampleButton.Click += (sender, e) => {
						StartActivity(typeof(LessonScreen));
				};
			}




			if(backButton != null) {
				backButton.Click += (sender, e) => {
					StartActivity(typeof(LanguageScreen));
				};
			}

			// wire up word click handler
			if(wordListView != null) {
				wordListView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => {
					var wordDetails = new Intent (this, typeof (LessonScreen));
					wordDetails.PutExtra ("WordID", words[e.Position].ID);
					StartActivity (wordDetails);
				};
			}

			// wire up task click handler
			if(tutorialButton != null) {
				tutorialButton.Click += (sender, e) => {
					StartActivity(typeof(ToneTutorial));
				};
			}
		}

		protected override void OnResume ()
		{
			base.OnResume ();

			words = WordManager.GetWords();

			// create our adapter
			wordList = new Adapters.WordListAdapter(this, words);

			//Hook up our adapter to our ListView
			wordListView.Adapter = wordList;

		}
	}
}