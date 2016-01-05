using System;
using SQLite;

namespace Project01 {
	/// <summary>
	/// Word object
	/// </summary
	public class word {
		public word ()
		{
		}

		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }

		public int Tone { get; set; }
		public string Word { get; set; }
		public string Translation { get; set; }
		public int Score { get; set; }
		//public Score currentScore { get; set; }
		public int Sound { get; set; }
		public string Chatacter { get; set; }

		public override string ToString()
		{
			return string.Format("[Person: Tone={0}, Word={1}, Translpation={2}, Chatacter={3}]", Tone, Word, Translation, Chatacter);
		}
	}
}