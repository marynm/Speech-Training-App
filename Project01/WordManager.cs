using System;
using System.Collections.Generic;

namespace Project01 {
	/// <summary>
	/// Manager classes are an abstraction on the data access layers
	/// </summary>
	public static class WordManager {

		static WordManager ()
		{
		}
		
		public static word GetWord(int id)
		{
			return WordRepositoryADO.GetWord(id);
		}
		
		public static IList<word> GetWords ()
		{
			return new List<word>(WordRepositoryADO.GetWords());
		}

		public static int SaveWord (word item)
		{
			return WordRepositoryADO.SaveWord(item);
		}
		
		public static int DeleteWord(int id)
		{
			return WordRepositoryADO.DeleteWord(id);
		}

	}
}