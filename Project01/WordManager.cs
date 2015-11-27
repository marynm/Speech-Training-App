/*using System;
using System.Collections.Generic;

namespace Project01 {
	/// <summary>
	/// Manager classes are an abstraction on the data access layers
	/// </summary>
	public static class WordManager {

		static WordManager ()
		{
		}
		
		public static Word GetWord(int id)
		{
			return WordRepositoryADO.GetWord(id);
		}
		
		public static IList<Word> GetWords ()
		{
			return new List<Word>(WordRepositoryADO.GetWords());
		}

		public static int SaveWord (Word item)
		{
			return WordRepositoryADO.SaveWord(item);
		}
		
		public static int DeleteWord(int id)
		{
			return WordRepositoryADO.DeleteWord(id);
		}

	}
}
*/