using System;
using System.Drawing;
using System.Windows.Forms;

namespace MinecraftResearchObservation
{
	public partial class PluginExecuteCommandsOnce4EachPlayerConfig : Form
	{
		public PluginExecuteCommandsOnce4EachPlayerConfig()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
		}
		
		public string[] _Commands
		{
			get
			{
				return this.textBoxCommands.Lines;
			}
		}
	}
}
