/*
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Tasky.Core;
using TaskyAndroid;
using Android.Views;
using Android.Graphics;

namespace TaskyAndroid.Screens {
	/// <summary>
	/// View/edit a Task
	/// </summary>
	[Activity (Label = "TaskDetailsScreen")]			
	public class TaskDetailsScreen : Activity {
		Task task = new Task();
		Button cancelDeleteButton;
		EditText notesTextEdit;
		EditText nameTextEdit;
		Button saveButton;
		CheckBox doneCheckBox;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			
			int taskID = Intent.GetIntExtra("TaskID", 0);
			if(taskID > 0) {
				task = TaskManager.GetTask(taskID);
			}
			
			// set our layout to be the home screen
			SetContentView(Resource.Layout.TaskDetails);
			nameTextEdit = FindViewById<EditText>(Resource.Id.NameText);
			notesTextEdit = FindViewById<EditText>(Resource.Id.NotesText);
			saveButton = FindViewById<Button>(Resource.Id.SaveButton);
			doneCheckBox = FindViewById<CheckBox> (Resource.Id.checkDone);

			// find all our controls
			cancelDeleteButton = FindViewById<Button>(Resource.Id.CancelDeleteButton);
			
			// set the cancel delete based on whether or not it's an existing task
			cancelDeleteButton.Text = (task.ID == 0 ? "Cancel" : "Delete");
			
			nameTextEdit.Text = task.Name; 
			notesTextEdit.Text = task.Notes;

			//Set the check box value
			doneCheckBox.Checked = task.Done;

			// button clicks 
			cancelDeleteButton.Click += (sender, e) => { CancelDelete(); };
			saveButton.Click += (sender, e) => { Save(); };

			//Title bar 
			View titleView = Window.FindViewById(Android.Resource.Id.Title);
			if (titleView != null) {
				IViewParent parent = titleView.Parent;
				if (parent != null && (parent is View)) {
					View parentView = (View)parent;
					parentView.SetBackgroundColor(Color.Rgb(0xFF, 0xD7 ,0x39)); //Gold
				}
			}
		}

		void Save()
		{
			task.Name = nameTextEdit.Text;
			task.Notes = notesTextEdit.Text;
			task.Done = doneCheckBox.Checked;
			TaskManager.SaveTask(task);
			Finish();
		}
		
		void CancelDelete()
		{
			if (task.ID != 0) {
				TaskManager.DeleteTask(task.ID);
			}
			Finish();
		}
	}
}
*/