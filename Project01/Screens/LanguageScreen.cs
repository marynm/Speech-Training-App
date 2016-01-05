using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Project01.Screens
{
	/// <summary>
	/// The initial launch screen of the porogram. Lists the languages available to learn and prompts user to select one to begin
	/// </summary>
	/// 
	/// 	

	[Activity (Label = "Project", MainLauncher = true, Icon = "@drawable/icon1")]
	public class LanguageScreen : Activity
	{

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.LanguageSelect);

			// Get our UI controls from the loaded layout:
			Button languageButton = FindViewById<Button>(Resource.Id.language);


			// wire up add task button handler
			if(languageButton != null) {
				languageButton.Click += (sender, e) => {

					//FOR TESTING, ADD SOME WORDS TO THE LANGUAGE AND CREATE DATABASE IF IT DOESN'T EXIST - ONLY NEED THIS THE FIRST TIME

				 	Toast.MakeText(this, "Adding sample words to the database", ToastLength.Long).Show();
					word w1 = new word();
					w1.Word = "mā"; 
					w1.Tone = 1;
					w1.Chatacter = "m";
					w1.Translation = "mother";
					w1.Sound = Resource.Raw.F1mother;
					WordManager.SaveWord(w1);

					word w2 = new word();
					w2.Word = "má"; 
					w2.Tone = 2;
					w2.Chatacter = "mm";
					w2.Translation = "numb";
					w2.Sound = Resource.Raw.F2numb;
					WordManager.SaveWord(w2);


					StartActivity(typeof(WordListScreen));
				};
			}
		}
	}
}