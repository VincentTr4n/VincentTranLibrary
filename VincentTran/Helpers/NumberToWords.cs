
namespace VincentTran.Helpers
{
	public enum Lang { VN, EN }

	/// <summary>
	/// /// This class can Convert a Number to Words
	/// </summary>

	public class NumberToWords
	{

		#region Components
		static readonly string[] ENGLISH_TENS_NAMES = { "", " ten", " twenty", " thirty", " forty", " fifty", " sixty", " seventy", " eighty", " ninety" };
		static readonly string[] VIETNAMES_TENS_NAMES = { "", " mười", " hai mươi", " ba mươi", " bốn mươi", " năm mươi", " sáu mươi", " bảy mươi", " tám mươi", " chín mươi" };

		static readonly string[] ENGLISH_NUM_NAMES = { "", " one", " two", " three", " four", " five", " six", " seven", " eight", " nine", " ten", " eleven", " twelve", " thirteen", " fourteen", " fifteen", " sixteen", " seventeen", " eighteen", " nineteen" };
		static readonly string[] VIETNAMESE_NUM_NAMES = { "", " một", " hai", " ba", " bốn", " năm", " sáu", " bảy", " tám", " chín", " mười", " mười một", " mười hai", " mười ba", " mười bốn", " mười lăm", " mười sáu", " mười bảy", " mười tám", " mười chín" };

		static readonly string ENGLISH_HUNDRED = " hundred", VIETNAMESE_HUNDRED = " trăm";
		static readonly string ENGLISH_THOUSAND = " thousand", VIETNAMESE_THOUSAND = " nghìn";
		static readonly string ENGLISH_MILLION = " million", VIETNAMESE_MILLION = " triệu";
		static readonly string ENGLISH_BILLION = " billion", VIETNAMESE_BILLION = " tỉ";
		
		string[] tensNames;
		string[] numNames;
		string hundred, thousand, million, billion;
		#endregion

		#region Constructor
		public NumberToWords(Lang lang)
		{
			if (lang == Lang.VN)
			{
				tensNames = VIETNAMES_TENS_NAMES;
				numNames = VIETNAMESE_NUM_NAMES;
				hundred = VIETNAMESE_HUNDRED;
				thousand = VIETNAMESE_THOUSAND;
				million = VIETNAMESE_MILLION;
				billion = VIETNAMESE_BILLION;
			}
			else
			{
				tensNames = ENGLISH_TENS_NAMES;
				numNames = ENGLISH_NUM_NAMES;
				hundred = ENGLISH_HUNDRED;
				thousand = ENGLISH_THOUSAND;
				million = ENGLISH_MILLION;
				billion = ENGLISH_BILLION;
			}
		} 
		#endregion

		/// <summary>
		/// Solve number less than 999
		/// </summary>
		/// <param name="number"></param>
		/// <returns></returns>

		string convertLessThanOneThousand(int number)
		{
			string soFar;

			if (number % 100 < 20)
			{
				soFar = numNames[number % 100];
				number /= 100;
			}
			else
			{
				soFar = numNames[number % 10];
				number /= 10;

				soFar = tensNames[number % 10] + soFar;
				number /= 10;
			}
			if (number == 0)
				return soFar;
			return numNames[number] + hundred + soFar;
		}

		/// <summary>
		/// Convert long Number to Words
		/// </summary>
		/// <param name="number"></param>
		/// <returns></returns>
		public string Convert(long number)
		{
			// 0 to 999 999 999 999
			if (number == 0)
			{
				return "zero";
			}

			string snumber = number.ToString("000000000000");

			// XXXnnnnnnnnn
			int billions = int.Parse(snumber.Substring(0, 3));
			// nnnXXXnnnnnn
			int millions = int.Parse(snumber.Substring(3, 3));
			// nnnnnnXXXnnn
			int hundredThousands = int.Parse(snumber.Substring(6, 3));
			// nnnnnnnnnXXX
			int thousands = int.Parse(snumber.Substring(9, 3));

			string tradBillions;
			switch (billions)
			{
				case 0:
					tradBillions = "";
					break;
				case 1:
					tradBillions = convertLessThanOneThousand(billions) + billion + " ";
					break;
				default:
					tradBillions = convertLessThanOneThousand(billions) + billion + " ";
					break;
			}
			string result = tradBillions;

			string tradMillions;
			switch (millions)
			{
				case 0:
					tradMillions = "";
					break;
				case 1:
					tradMillions = convertLessThanOneThousand(millions) + million + " ";
					break;
				default:
					tradMillions = convertLessThanOneThousand(millions) + million + " ";
					break;
			}
			result = result + tradMillions;

			string tradHundredThousands;
			switch (hundredThousands)
			{
				case 0:
					tradHundredThousands = "";
					break;
				case 1:
					tradHundredThousands = numNames[1] + thousand + " ";
					break;
				default:
					tradHundredThousands = convertLessThanOneThousand(hundredThousands) + thousand + " ";
					break;
			}
			result = result + tradHundredThousands;

			string tradThousand;
			tradThousand = convertLessThanOneThousand(thousands);
			result = result + tradThousand;

			// remove extra spaces!
			return result.Replace("^\\s+", "").Replace("\\b\\s{2,}\\b", " ").Trim();
		}
	}
}
