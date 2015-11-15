using Project01;
using Android.Graphics;
using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Media;

namespace Project01.Screens {
	/// <summary>
	/// The main lesson for a particular word, inlcuding recording and playback features and the visual feedback
	/// </summary>
	/// 
	/// 	


	[Activity (Label = "Project")]			
	public class LessonScreen : Activity {


		MediaRecorder _recorder;
		Button _record_button;
		bool recording = false;
		bool recording_made = false;
		bool playing = false;

		MediaPlayer _player;
		Button _playback_button;
		Button _play_word;

		private static String mFileName = null;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Lesson);

			_play_word = FindViewById<Button> (Resource.Id.currentWord);

			_play_word.Click += delegate {

				if(!playing) {
					_player = MediaPlayer.Create (this, Resource.Raw.test);
					_player.Start ();
					playing = true;
				}
				else {
					_player.Stop ();
					playing = false;
				}
					
			};

				_record_button = FindViewById<Button> (Resource.Id.record_button);
				//string path = "/sdcard/recording.3gpp";		//location to temporarily hold recorded file
				string path = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + "/test.3gpp";
				//mFileName = Android.OS.Environment.GetExternalStoragePublicDirectory().AbsolutePath();
				//mFileName += "/audiorecordtest.3gpp";

				_record_button.Click += delegate {
					//first press of Speak button starts recording, secodn press stops
					//record_button.Enabled = !record_button.Enabled;

					if (!recording) {
						_recorder.SetAudioSource (AudioSource.Mic);
						_recorder.SetOutputFormat (OutputFormat.ThreeGpp);
						_recorder.SetAudioEncoder (AudioEncoder.AmrNb);
						_recorder.SetOutputFile (path);
						_recorder.Prepare ();
						_recorder.Start ();
						recording = true;
					} else {
						_recorder.Stop ();
						_recorder.Reset ();
						recording = false;
						recording_made = true;
					}

				};

			_playback_button = FindViewById<Button> (Resource.Id.listen_button);

			_playback_button.Click += delegate {
				//Pressing Listen button cuases the user recodeing to play back

				if(recording_made) {
					_player.SetDataSource (path);
					_player.Prepare ();
					_player.Start ();
				}
				else if(playing) {
					_player.Stop ();
					playing = false;
				}
				else {
					_player = MediaPlayer.Create(this, Resource.Raw.test);
					_player.Start ();
					playing = true;
				}


			};
				
			}

			protected override void OnResume ()
			{
				base.OnResume ();

				_recorder = new MediaRecorder ();
				_player = new MediaPlayer ();

				_player.Completion += (sender, e) => {
					_player.Reset ();
					_record_button.Enabled = !_record_button.Enabled;
				};
			}



			protected override void OnPause ()
			{
				base.OnPause ();

				//realease media recorder and player while they are not needed (ie when app paused)
				_player.Release ();
				_recorder.Release ();
				_player.Dispose ();
				_recorder.Dispose ();
				_player = null;
				_recorder = null;
			}

		}
	}