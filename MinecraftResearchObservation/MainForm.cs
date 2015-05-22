using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinecraftResearchObservation
{
	public partial class MainForm : Form
	{
		private string destinationFolder = Environment.CurrentDirectory;
		private string metaInformation = string.Empty;
		private string minecraftServer = string.Empty;
		private string minecraftRCONPassword = string.Empty;
		private bool isRunning = false;
		
		public MainForm(string destinationFolder, string metaInformation, string minecraftServer, string minecraftRCONPassword)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
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
			
			new DebugWindow().Show(this);
			DebugWindow.writeLine(string.Format("Init done: Ready.\n"));
		}
		
		void ButtonStartClick(object sender, EventArgs e)
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
		
		void ButtonStopClick(object sender, EventArgs e)
		{
			this.isRunning = false;
			
			//Screenshot.stopAutoScreenshot();
			RCONLogic.stopLogic();
			CSVWriter.stopWriter();
			
			DebugWindow.writeLine(string.Format("Stop recording.\n"));
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
	}
}
