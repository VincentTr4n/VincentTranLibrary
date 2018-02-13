using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VincentTran.Algorithms
{
	public static class HammingEncoding
	{
		public static string GetHammingEndcode(this string input)
		{
			int r = 0, m = input.Length;
			//calculate number of parity bits needed using m+r+1<=2^r
			while (m + r + 1 >= Math.Pow(2, r)) r++;
			
			int transLength = input.Length + r, temp = 0, temp2 = 0, j = 0;
			int[] transMsg = new int[transLength + 1]; //+1 because starts with 1
			for (int i = 1; i <= transLength; i++)
			{
				// Add elment of transaction message in array + bits parity
				temp2 = (int)Math.Pow(2, temp);
				if (i % temp2 != 0) transMsg[i] = input[j++] - '0';
				else temp++;
			}

			for (int i = 0; i < r; i++)
			{
				int Step = (int)Math.Pow(2, i);
				int NextStep = Step * 2;
				int start = Step, check = start;
				while (true)
				{
					for (int k = start; k <= start + Step - 1; k++)
					{
						check = k;
						if (k > transLength) break;
						transMsg[Step] ^= transMsg[check];
					}
					if (check > transLength) break;
					else start = start + NextStep;
				}
			}
			string res = "";
			for (int i = 1; i <= transLength; i++) res += transMsg[i].ToString();
			return res;
		}
		// Detect error bit
		public static string DectectAndFix(string input)
		{
			int r = 0;
			while (input.Length >= Math.Pow(2, r)) r++;

			int[] transMsg = new int[input.Length + 1];

			for (int i = 0; i < input.Length; i++) transMsg[i + 1] = input[i] - '0';

			int error = 0;
			for (int i = 0; i < r; i++)
			{
				int Step = (int)Math.Pow(2, i);
				int NextStep = Step * 2;
				int start = Step, check = start;
				int temp = transMsg[Step];
				transMsg[Step] = 0;
				while (true)
				{
					for (int k = start; k <= start + Step - 1; k++)
					{
						check = k;
						if (k > input.Length) break;
						transMsg[Step] ^= transMsg[check];
					}
					if (check > input.Length) break;
					else start = start + NextStep;
				}
				if (temp != transMsg[Step]) error += Step;
			}

			StringBuilder res = new StringBuilder();

			transMsg[error] = transMsg[error] == 1 ? 0 : 1;  // fixed error
			int j = 0;
			for (int i = 1; i < transMsg.Length; i++)
			{
				// remove all bit parity
				if (i != (int)Math.Pow(2, j)) res.Append(transMsg[i].ToString());
				else j++;
			}
			// string binary of package fixed and index error bit
			return res.ToString() + "|error:" + error;
		}
	}

}