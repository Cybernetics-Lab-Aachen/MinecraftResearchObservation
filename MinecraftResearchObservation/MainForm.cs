using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using NETools.IO;
using System.Reflection;
using System.Linq;

namespace MinecraftResearchObservation
{
	public partial class MainForm : Form
	{
		private string destinationFolder = Environment.CurrentDirectory;
		private string metaInformation = string.Empty;
		private string minecraftServer = string.Empty;
		private string minecraftRCONPassword = string.Empty;
		private string version = string.Empty;
		private bool isRunning = false;
		private ReaderWriterLockSlim stateLock = new ReaderWriterLockSlim();
		
		public MainForm(string destinationFolder, string metaInformation, string minecraftServer, string minecraftRCONPassword)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			// Get the own version:
			var versionAttribute = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyFileVersionAttribute), true).FirstOrDefault() as AssemblyFileVersionAttribute; 
			this.version = versionAttribute != null ? versionAttribute.Version : "0";
			
			// Write the title:
			this.Text = string.Format("[Mine]craft [Re]search [Obs]ervation v{0}: {1}", version, metaInformation);
			
			this.destinationFolder = destinationFolder;
			this.metaInformation = metaInformation;
			this.minecraftServer = minecraftServer;
			this.minecraftRCONPassword = minecraftRCONPassword;
			
			Screenshot.setDestinationFolder(this.destinationFolder);
			Screenshot.setMetaInformation(this.metaInformation);
			CSVWriter.setMetaInfo(this.metaInformation);
			CSVWriter.setDestinationFolder(this.destinationFolder);
			RCONLogic.setMinecraftServer(this.minecraftServer);
			RCONLogic.setMinecraftRCONPassword(this.minecraftRCONPassword);
			
			new DebugWindow(string.Format("[Mine]craft [Re]search [Obs]ervation v{0}, Messages: {1}", version, metaInformation)).Show(this);
			
			// Redirect any outpout to the standard out also in the message i.e. debug window:
			Console.SetOut(new LineEventWriter(lineReceiver));
			DebugWindow.writeLine(string.Format("Init done: Ready.\n"));
		}
		
		private bool lineReceiver(string line)
		{
			// Redirect any outpout to the standard out also in the message i.e. debug window:
			DebugWindow.writeLine(line + '\n');
			return true;
		}
		
		void ButtonStartClick(object sender, EventArgs e)
		{
			this.stateLock.EnterWriteLock();
			
			try
			{
				if(this.isRunning)
				{
					return;
				}
				
				this.isRunning = true;
				this.buttonState.Text = "State: Running";
				
				DebugWindow.writeLine(string.Format("Start recording.\n"));
				
				//Screenshot.startAutoScreenshot(8);
				CSVWriter.startWriter();
				RCONLogic.startLogic();
				Task.Factory.StartNew(() => 
	            {
	              	while(this.isRunning)
	              	{
	              		animation();
	              		Thread.Sleep(500);
	              	}
	              	
	              	resetAnimation();
	            }, TaskCreationOptions.LongRunning);
			}
			catch
			{
			}
			finally
			{
				this.stateLock.ExitWriteLock();
			}
		}
		
		void ButtonStopClick(object sender, EventArgs e)
		{
			this.stateLock.EnterWriteLock();
			
			try
			{
				if(!this.isRunning)
				{
					return;
				}
				
				Task.Run(() => {
					//Screenshot.stopAutoScreenshot();
					RCONLogic.stopLogic();
					CSVWriter.stopWriter();
					
					this.isRunning = false;
					DebugWindow.writeLine(string.Format("Stop recording.\n"));
				});
			}
			catch
			{
			}
			finally
			{
				this.stateLock.ExitWriteLock();
			}
		}
		
		void resetAnimation()
		{
			if(this.buttonState.InvokeRequired)
			{
				this.buttonState.Invoke(new ThreadStart(resetAnimation));
			}
			
			this.buttonState.BackColor = Color.LightGray;
			this.buttonState.Text = "State: Stopped";
		}
		
		void animation()
		{
			if(this.buttonState.InvokeRequired)
			{
				this.buttonState.Invoke(new ThreadStart(animation));
			}
			
			var color = this.buttonState.BackColor;
			if(color == Color.LightGray)
			{
				this.buttonState.BackColor = Color.DarkOrange;
			}
			else if (color == Color.DarkOrange)
			{
				this.buttonState.BackColor = Color.Red;
			}
			else
			{
				this.buttonState.BackColor = Color.LightGray;
			}
		}
		
		void ButtonClearClick(object sender, EventArgs e)
		{
			DebugWindow.clearWindow();
		}
		
		void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			if(this.isRunning)
			{
				MessageBox.Show("In order to close the window, you have to stop the recording!", "Recording is still running", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
				e.Cancel = true;
				return;
			}
		}
		
		void ButtonPluginDistributedInventoryClick(object sender, EventArgs e)
		{
			if(!PluginDistributedInventory.PluginIsActive)
			{
				var dialog = new PluginDistributedInventoryConfig();
				if(dialog.ShowDialog(this) != DialogResult.OK)
				{
					return;
				}
				
				PluginDistributedInventory.DestinationCountPlayers = dialog._CountPlayers;
				PluginDistributedInventory.Items = dialog._Items;
				PluginDistributedInventory.RestrictedWorldCommand = dialog._RestrictedWorldCommand;
			}
			
			PluginDistributedInventory.PluginIsActive = !PluginDistributedInventory.PluginIsActive;
			this.buttonPluginDistributedInventory.BackColor = PluginDistributedInventory.PluginIsActive ? Color.Orange : Color.LightGray;
		}
		
		void ButtonPluginExcuteCommands4EachPlayerOnceClick(object sender, EventArgs e)
		{
			if(!PluginExecuteCommandsOnce4EachPlayer.PluginIsActive)
			{
				var dialog = new PluginExecuteCommandsOnce4EachPlayerConfig();
				if(dialog.ShowDialog(this) != DialogResult.OK)
				{
					return;
				}
				
				PluginExecuteCommandsOnce4EachPlayer.Commands = dialog._Commands;
			}
			
			PluginExecuteCommandsOnce4EachPlayer.PluginIsActive = !PluginExecuteCommandsOnce4EachPlayer.PluginIsActive;
			this.buttonPluginExcuteCommands4EachPlayerOnce.BackColor = PluginExecuteCommandsOnce4EachPlayer.PluginIsActive ? Color.Orange : Color.LightGray;
		}
	}
}
