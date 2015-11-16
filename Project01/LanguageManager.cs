using System;
using System.Collections.Generic;

namespace Project01 {
	/// <summary>
	/// Manager classes are an abstraction on the data access layers
	/// </summary>
	public static class LanguageManager {

		static LanguageManager ()
		{
		}

		public static Language GetLanguage(int id)
		{
			return LanguageRepositoryADO.GetLanguage(id);
		}

		public static IList<Language> GetLanguages ()
		{
			return new List<Language>(LanguageRepositoryADO.GetLanguages());
		}

		public static int SaveLanguage (Language item)
		{
			return LanguageRepositoryADO.SaveLanguage(item);
		}

		public static int DeleteWLanguage(int id)
		{
			return LanguageRepositoryADO.DeleteLanguage(id);
		}

	}
}
