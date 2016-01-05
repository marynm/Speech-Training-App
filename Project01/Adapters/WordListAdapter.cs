using System.Collections.Generic;
using Android.App;
using Android.Widget;

namespace Project01.Adapters {
	/// <summary>
	/// Adapter that presents Words in a row-view
	/// </summary>
	public class WordListAdapter : BaseAdapter<word> {
		Activity context = null;
		IList<word> words = new List<word>();
		
		public WordListAdapter (Activity context, IList<word> words) : base ()
		{
			this.context = context;
			this.words = words;
		}
		
		public override word this[int position]
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
					Android.Resource.Layout.SimpleListItem1, 
					parent, 
					false)) as TextView;

			view.SetText (item.Word==""?"<new word>":item.Word, TextView.BufferType.Normal);
		

			// Find references to each subview in the list item's view
			//var txtWord = view.FindViewById<TextView>(Resource.Id.NameText);
			//var txtTranslation = view.FindViewById<TextView>(Resource.Id.NotesText);

			//Assign item's values to the various subviews
			//txtWord.SetText (item.Word, TextView.BufferType.Normal);
			//txtTranslation.SetText (item.Translation, TextView.BufferType.Normal);

			//Finally return the view
			return view;
		}
	}
}
