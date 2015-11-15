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
						StartActivity(typeof(WordListScreen));
					};
				}
		}
	}
}