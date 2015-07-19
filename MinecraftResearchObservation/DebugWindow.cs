using System;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace MinecraftResearchObservation
{
	public partial class DebugWindow : Form
	{
		private static StringBuilder sb = new StringBuilder();
		private static ReaderWriterLockSlim mutex = new ReaderWriterLockSlim();
		
		public DebugWindow()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			Task.Factory.StartNew(() =>
	        {
              	while(true)
              	{
					Thread.Sleep(TimeSpan.FromSeconds(2));
					this.refreshText();
              	}
			}, TaskCreationOptions.LongRunning);
		}
		
		public static void clearWindow()
		{
			Task.Run(() =>
	        {
	         	try
				{
					DebugWindow.mutex.EnterWriteLock();
					DebugWindow.sb.Clear();
				}
				catch
				{
				}
				finally
				{
					DebugWindow.mutex.ExitWriteLock();
				}
	        });
		}
		
		private void refreshText()
		{
			if(this.textBox.InvokeRequired)
			{
				this.textBox.Invoke(new ThreadStart(refreshText));
				return;
			}
			
			try
			{
				this.textBox.Clear();
				DebugWindow.mutex.EnterWriteLock();
				this.textBox.Lines = DebugWindow.sb.ToString().Split('\n').Reverse().ToArray();
			}
			catch
			{
			}
			finally
			{
				DebugWindow.mutex.ExitWriteLock();
			}
		}
		
		public static void writeLine(string line)
		{
			Task.Run(() =>
	        {
	         	try
				{
					DebugWindow.mutex.EnterWriteLock();
					DebugWindow.sb.Append(line);
				}
				catch
				{
				}
				finally
				{
					DebugWindow.mutex.ExitWriteLock();
				}
	        });
		}
	}
}
