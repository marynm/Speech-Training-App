using System;

namespace Project01
{
	public class Score
	{
		int frequencyScore;
		int pitchScore;
		public int Total;

		public Score()
		{	//an example of how the score might be calculated from the pitch tracking and frequency elements of the score acquired by the (as yet unwritten) score algorithm
			Total = (frequencyScore + pitchScore) / 2;
		}
	}
}