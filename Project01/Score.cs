using System;
using System.Collections.Generic;
using System.IO;

using Android.App;
using Android.Widget;
using Android.OS;


namespace Project01
{
	public class Scorer
	{
		/*
		 * Return a score (range 0-10) for a Tone 1 word
		*/
		public static int ToneOne(int[] data, int size)
		{
			//percent difference allowance
			int x = 1/10; //currently using 10%
			int i;

			//(assuming this is a 'cleaned' array of the data values (any outlying annomolies removed)

			//if all points are within percent difference range, return 'perfect' score (10)

			//find average
			int check = 0;
			int average = getAvg(data, size);

			//determine if all data points are within x% of the average
			for (i = 0; i < size; i++) {
				if (data [i] > (average + average * x) || data [i] < (average - average * x)) {
					check = 1;
					break;
				}
			}
			if (check == 0)
				return 10;
			
			//else give score based on percentage of points within range (also display where in word the majority of the incorrect points are/where to make imporvements??)
			int beginning = 0, middle = 0, end = 0;

			for(i = 0; i<(size/3); i++)
				if (data [i] > (average + average * x) || data [i] < (average - average * x))
					beginning++;
			for(i = (size/3); i<(2*size/3); i++)
				if (data [i] > (average + average * x) || data [i] < (average - average * x))
					middle++;
			for(i = (2*size/3); i<size; i++)
				if (data [i] > (average + average * x) || data [i] < (average - average * x))
					end++;

			//display whether most issues are in the beginning, middle, or end sections
		//	if(beginning >= middle && beginning >= end)
			//Toast.MakeText(this, "Pay attention to the tone at the beginning of the syllable", ToastLength.Long).Show();
		//	else if (middle > beginning && middle > end)
				//Toast.MakeText(this, "Pay attention to the tone in the middle of the syllable", ToastLength.Long).Show();
		//	else if (end > beginning && end > middle)
				//Toast.MakeText(this, "Pay attention to the tone in the middle of the syllable", ToastLength.Long).Show();

			//calculate and return score in range of 0-10
			int count = beginning + middle + end;
			float unroundedScore = (count/size) * 10;
			return (int)(unroundedScore + 0.5);
		}

		public static int ToneTwo(int[] data, int size)
		{
			return 0;
		}

		public static int ToneThree(int[] data, int size)
		{
			return 0;
		}

		public static int ToneFour(int[] data, int size)
		{
			return 0;
		}

		/*
		 * Find the average of an array of data points
		*/
		private static int getAvg(int[] data, int size)
		{
			int i;
			int avg = 0;

			for (i = 0; i < size; i++) 
				avg += data [i];

			avg = avg / size;

			return avg;
		}

	}
}