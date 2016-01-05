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
		int word_sample = -1;

		MediaPlayer _player;
		Button _playback_button;
		Button _play_word;
		TextView _tone;

		word currentWord = new word ();


		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			int wordID = Intent.GetIntExtra("WordID", 0);
			if(wordID > 0) {
				currentWord = WordManager.GetWord(wordID);
			}

			//Set up and connect view
			SetContentView (Resource.Layout.Lesson);
			_play_word = FindViewById<Button> (Resource.Id.playWord);
			_record_button = FindViewById<Button> (Resource.Id.record_button);
			_tone = FindViewById<TextView> (Resource.Id.toneNumber);
			_playback_button = FindViewById<Button> (Resource.Id.listen_button);
			_playback_button.Enabled = false;

			//get attributes from current word in database
			_play_word.Text = currentWord.Word;
			_tone.Text = currentWord.Tone.ToString();
			word_sample = currentWord.Sound;


			_play_word.Click += delegate {

				if(!playing) {
					_player = MediaPlayer.Create (this, word_sample);
					_player.Start ();
					playing = true;
				}
				else {
					_player.Stop ();
					playing = false;
				}
					
			};
				
				string path = "/sdcard/Recording.mp3";		//location to temporarily hold recorded file
				//string path = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + "/test.3gpp";

				_record_button.Click += delegate {
					//first press of Speak button starts recording, secodn press stops
					//record_button.Enabled = !record_button.Enabled;

					if(!recording_made && !recording) {
						_recorder.SetAudioSource (AudioSource.Mic);
						_recorder.SetOutputFormat (OutputFormat.Mpeg4);
						_recorder.SetAudioEncoder (AudioEncoder.Aac);
						_recorder.SetOutputFile (path);
					}

					if (!recording) {

						//_recorder.Prepare ();
						//_recorder.Start ();
						recording = true;
						_record_button.Text = "Done Speaking";
					} else {
						//_recorder.Stop ();
						//_recorder.Reset ();
						recording = false;
						_record_button.Text = "Speak";
						recording_made = true;
						_playback_button.Enabled = true;
					}

				};
				

			_playback_button.Click += delegate {
				//Pressing Listen button cuases the user recording to play back
				if(recording_made) {
					_player.SetDataSource (path);
					_player.Prepare ();
					_player.Start ();
					playing = true;
				}
				else if(playing) {
					_player.Stop ();
					playing = false;
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