using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace VincentTran.Cryptography
{
	public static class StringEncoder
	{
        const int size = 256;
        const int interation = 1997;

		#region EncrytString
		public static string EncrytString(this string text, string stringKey)
        {
            var saltStringBytes = Random256bitsGenerator();
            var ivStringBytes = Random256bitsGenerator();
            var TextBytes = Encoding.UTF8.GetBytes(text);
            var password = new Rfc2898DeriveBytes(stringKey, saltStringBytes, interation);
            var key = password.GetBytes(size / 8);
            var rijndael = new RijndaelManaged();
            rijndael.BlockSize = 256;
            rijndael.Mode = CipherMode.CBC;
            rijndael.Padding = PaddingMode.PKCS7;
            var encryptor = rijndael.CreateEncryptor(key, ivStringBytes);
            var memory = new MemoryStream();
            var cryptorStream = new CryptoStream(memory, encryptor, CryptoStreamMode.Write);
            cryptorStream.Write(TextBytes, 0, TextBytes.Length);
            cryptorStream.FlushFinalBlock();
            var pwTextBytes = saltStringBytes;
            pwTextBytes = pwTextBytes.Concat(ivStringBytes).ToArray();
            pwTextBytes = pwTextBytes.Concat(memory.ToArray()).ToArray();
            memory.Close();
            cryptorStream.Close();
			return new System.Numerics.BigInteger(pwTextBytes).ToString();
		}
		#endregion

		#region DecrytString
		public static string DecrytString(this string encryptString, string stringKey)
        {
			var pwBytesSaltAndIV = System.Numerics.BigInteger.Parse(encryptString).ToByteArray();
			var SaltStringBytes = pwBytesSaltAndIV.Take(size / 8).ToArray();
            var ivStringBytes = pwBytesSaltAndIV.Skip(size / 8).Take(size / 8).ToArray();
            var pwBytes = pwBytesSaltAndIV.Skip((size * 2) / 8).Take(pwBytesSaltAndIV.Length - (size * 2) / 8).ToArray();
            var password = new Rfc2898DeriveBytes(stringKey, SaltStringBytes, interation);
            var key = password.GetBytes(size / 8);
            var rijndael = new RijndaelManaged();
            rijndael.BlockSize = 256;
            rijndael.Mode = CipherMode.CBC;
            rijndael.Padding = PaddingMode.PKCS7;
            var decryptor = rijndael.CreateDecryptor(key, ivStringBytes);
            var memory = new MemoryStream(pwBytes);
            var cryptorStream = new CryptoStream(memory, decryptor, CryptoStreamMode.Read);
            var textBytes = new byte[pwBytes.Length];
            var count = cryptorStream.Read(textBytes, 0, textBytes.Length);
            memory.Close();
            cryptorStream.Close();
            return Encoding.UTF8.GetString(textBytes, 0, count);
        }

		#endregion

		#region BitsGenerator

		private static byte[] Random256bitsGenerator()
        {
            var random = new byte[32];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(random);
            return random;
        }
		#endregion
	}
}
