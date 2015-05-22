using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MinecraftResearchObservation
{
	public static class CSVWriter
	{
		private static bool isRunning = false;
		private static string destinationFolder = string.Empty;
		private static string metaInfo = string.Empty;
		private static StringBuilder sb = new StringBuilder();
		private static ReaderWriterLockSlim mutex = new ReaderWriterLockSlim();
		
		public static void setMetaInfo(string metaInfo)
		{
			CSVWriter.metaInfo = metaInfo;
		}
		
		public static void setDestinationFolder(string destinationFolder)
		{
			CSVWriter.destinationFolder = destinationFolder;
		}
		
		public static void startWriter()
		{
			if(CSVWriter.isRunning)
			{
				return;
			}
			
			CSVWriter.isRunning = true;
			DebugWindow.writeLine(string.Format("Starting the CSVWriter now.\n"));
			
			CSVWriter.mutex.EnterWriteLock();
			CSVWriter.sb.Clear();
			CSVWriter.mutex.ExitWriteLock();
			
			Task.Factory.StartNew(() =>
	        {
               	var filename = string.Format("{1}SpatialStorage-{2}-{0:yyyyMMddHHmmss}.data", DateTime.Now, CSVWriter.destinationFolder, CSVWriter.metaInfo);
              	while(CSVWriter.isRunning)
              	{
              		Thread.Sleep(TimeSpan.FromSeconds(10));
              		try
              		{
              			CSVWriter.mutex.EnterWriteLock();
              			var data = CSVWriter.sb.ToString();
              			File.AppendAllText(filename, data);
              			DebugWindow.writeLine(data);
              		}
              		catch(Exception e)
              		{
              			DebugWindow.writeLine(string.Format("Exception: {0}\n", e.Message));
              			DebugWindow.writeLine(string.Format("Exception: {0}\n", e.StackTrace));
              		}
              		finally
              		{
              			CSVWriter.sb.Clear();
              			CSVWriter.mutex.ExitWriteLock();
              		}
              	}
              	DebugWindow.writeLine(string.Format("The CSVWriter is stopped now.\n"));
			}, TaskCreationOptions.LongRunning);
		}
		
		public static void stopWriter()
		{
			CSVWriter.isRunning = false;
		}
		
		public static void writeLine(string line)
		{
			try
			{
				CSVWriter.mutex.EnterWriteLock();
				CSVWriter.sb.Append(line);
			}
			catch(Exception e)
	  		{
	  			DebugWindow.writeLine(string.Format("Exception: {0}\n", e.Message));
	  			DebugWindow.writeLine(string.Format("Exception: {0}\n", e.StackTrace));
	  		}
			finally
			{
				CSVWriter.mutex.ExitWriteLock();
			}
		}
	}
}
