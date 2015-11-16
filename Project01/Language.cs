using System;

namespace Project01 {
	/// <summary>
	/// Language object
	/// </summary>
	public class Language {
		public Language ()
		{
		}
		public int ID { get; set; }
		public string Name { get; set; }
		public string Definition { get; set; }
		public int Score { get; set; }
		public string Sound { get; set; }
	}
}