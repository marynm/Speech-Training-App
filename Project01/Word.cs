using System;

namespace Project01 {
	/// <summary>
	/// Word object
	/// </summary>
	public class Word {
		public Word ()
		{
		}
		public int ID { get; set; }
		public string Name { get; set; }
		public string Definition { get; set; }
		public int Score { get; set; }
		public string Sound { get; set; }
	}
}