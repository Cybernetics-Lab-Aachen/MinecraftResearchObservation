using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinecraftResearchObservation
{
	public static class Screenshot
	{
		private static string destinationFolder = Environment.CurrentDirectory;
		private static string metaInformation = string.Empty;
		private static Font font = new Font(new Font(FontFamily.GenericSerif, 12), FontStyle.Bold);
		private static bool autoScreenshotRunning = false;
		private static uint counter = 0;
		
		public static void setDestinationFolder(string destinationFolder)
		{
			Screenshot.destinationFolder = destinationFolder;
		}
		
		public static void setMetaInformation(string metaInformation)
		{
			Screenshot.metaInformation = metaInformation;
		}
		
		public static void getNextScreenshot()
		{
			Screenshot.counter++;
			var text = string.Format("{0:yyyy.MM.dd HH:mm:ss:fff} {1}", DateTime.UtcNow, Screenshot.metaInformation);
			using(var bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb))
			{
				using(var g = Graphics.FromImage(bitmap))
				{
					var dim = g.MeasureString(text, Screenshot.font);
					
					g.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
					g.FillRectangle(Brushes.Gray, 12, bitmap.Height - 20, dim.Width, dim.Height);
					g.DrawString(text, Screenshot.font, Brushes.Black, 12, bitmap.Height - 20);
				}
				
				bitmap.Save(string.Format("{1}{0}{3:0000} {2}.jpg", Path.DirectorySeparatorChar, Screenshot.destinationFolder, Guid.NewGuid().ToString(), Screenshot.counter), ImageFormat.Jpeg);
			}
		}
		
		public static void startAutoScreenshot(byte screenshotsPerSecond)
		{
			if(Screenshot.autoScreenshotRunning)
			{
				return;
			}
			
			var waitTimeMilliseconds = (int) (1000f / screenshotsPerSecond);
			Screenshot.autoScreenshotRunning = true;
			Task.Factory.StartNew(() =>
	        {
              	while(Screenshot.autoScreenshotRunning)
              	{
	              	Screenshot.getNextScreenshot();
	              	Thread.Sleep(waitTimeMilliseconds);
              	}
			}, TaskCreationOptions.LongRunning);
		}
		
		public static void stopAutoScreenshot()
		{
			Screenshot.autoScreenshotRunning = false;
		}
	}
}
