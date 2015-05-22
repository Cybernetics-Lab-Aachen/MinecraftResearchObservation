using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MinecraftResearchObservation
{
	public partial class BaseInformation : Form
	{
		private string destinationFolder = Environment.CurrentDirectory;
		private string metaInformation = string.Empty;
		private string minecraftServer = "127.0.0.1";
		private string minecraftRCONPassword = string.Empty;
		
		public BaseInformation()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			this.metaInformation = global::MinecraftResearchObservation.Properties.Settings1.Default.MetaInformation.Trim();
			this.minecraftServer = global::MinecraftResearchObservation.Properties.Settings1.Default.MinecraftServer.Trim();
			this.minecraftRCONPassword = global::MinecraftResearchObservation.Properties.Settings1.Default.MinecraftRCONPassword.Trim();

			if(global::MinecraftResearchObservation.Properties.Settings1.Default.DestinationFolder.Trim() != string.Empty)
			{
				this.destinationFolder = global::MinecraftResearchObservation.Properties.Settings1.Default.DestinationFolder;
			}
			
			if(this.metaInformation != string.Empty)
			{
				this.textBoxMetaInformation.Text = this.metaInformation;
			}
			
			if(this.minecraftServer != string.Empty)
			{
				this.textBoxMinecraftServer.Text = this.minecraftServer;
			}
			
			if(this.minecraftRCONPassword != string.Empty)
			{
				this.textBoxRCONPassword.Text = this.minecraftRCONPassword;
			}
		}
		
		void ButtonDestinationFolderClick(object sender, EventArgs e)
		{
			using(var fbd = new FolderBrowserDialog())
			{
				fbd.Description = "Please select the destination folder";
				fbd.SelectedPath = this.destinationFolder;
				fbd.ShowNewFolderButton = true;
				var result = fbd.ShowDialog(this);
				
				if(result == DialogResult.OK)
				{
					this.destinationFolder = fbd.SelectedPath;
					if(!this.destinationFolder.EndsWith(string.Empty + Path.DirectorySeparatorChar))
					{
						this.destinationFolder += Path.DirectorySeparatorChar;
					}
				}
			}
		}
		
		void ButtonOKClick(object sender, EventArgs e)
		{
			this.metaInformation = this.textBoxMetaInformation.Text;
			this.minecraftServer = this.textBoxMinecraftServer.Text;
			this.minecraftRCONPassword = this.textBoxRCONPassword.Text;
			
			global::MinecraftResearchObservation.Properties.Settings1.Default.DestinationFolder = this.destinationFolder;
			global::MinecraftResearchObservation.Properties.Settings1.Default.MetaInformation = this.metaInformation;
			global::MinecraftResearchObservation.Properties.Settings1.Default.MinecraftServer = this.minecraftServer;
			global::MinecraftResearchObservation.Properties.Settings1.Default.MinecraftRCONPassword = this.minecraftRCONPassword;
			global::MinecraftResearchObservation.Properties.Settings1.Default.Save();
		}
		
		public string _DestinationFolder
		{
			get
			{
				return this.destinationFolder;
			}
		}
		
		public string _MetaInformation
		{
			get
			{
				return this.metaInformation;
			}
		}
		
		public string _MinecraftServer
		{
			get
			{
				return this.minecraftServer;
			}
		}
		
		public string _MinecraftRCONPassword
		{
			get
			{
				return this.minecraftRCONPassword;
			}
		}
	}
}
