using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace VincentTran.Helpers
{
	public static class ImageHelpers
	{
		public static byte[] ImageToByteArray(this Image imageIn, ImageFormat format)
		{
			var ms = new MemoryStream();
			imageIn.Save(ms, format);
			return ms.ToArray();
		}


		public static Image ByteArrayToImage(this byte[] bytesArr)
		{
			var memstr = new MemoryStream(bytesArr);
			var img = Image.FromStream(memstr);
			return img;
		}
	}
}
