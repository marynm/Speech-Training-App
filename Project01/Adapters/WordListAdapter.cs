using System.Collections.Generic;
using Android.App;
using Android.Widget;

namespace Project01.Adapters {
	/// <summary>
	/// Adapter that presents Words in a row-view
	/// </summary>
	public class WordListAdapter : BaseAdapter<Word> {
		Activity context = null;
		IList<Word> words = new List<Word>();
		
		public WordListAdapter (Activity context, IList<Word> tasks) : base ()
		{
			this.context = context;
			this.words = words;
		}
		
		public override Word this[int position]
		{
			get { return words[position]; }
		}
		
		public override long GetItemId (int position)
		{
			return position;
		}
		
		public override int Count
		{
			get { return words.Count; }
		}
		
		public override Android.Views.View GetView (int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
		{
			// Get our object for position
			var item = words[position];			

			//Try to reuse convertView if it's not  null, otherwise inflate it from our item layout
			// gives us some performance gains by not always inflating a new view
			// will sound familiar to MonoTouch developers with UITableViewCell.DequeueReusableCell()
			var view = (convertView ?? 
					context.LayoutInflater.Inflate(
					Android.Resource.Layout.SimpleListItemChecked, 
					parent, 
					false)) as CheckedTextView;

			view.SetText (item.Name==""?"<new task>":item.Name, TextView.BufferType.Normal);
		

			// Find references to each subview in the list item's view
			//var txtName = view.FindViewById<TextView>(Resource.Id.NameText);
			//var txtDescription = view.FindViewById<TextView>(Resource.Id.NotesText);

			//Assign item's values to the various subviews
			//txtName.SetText (item.Name, TextView.BufferType.Normal);
			//txtDescription.SetText (item.Notes, TextView.BufferType.Normal);

			//Finally return the view
			return view;
		}
	}
}