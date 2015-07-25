using System;
using System.Drawing;
using System.Windows.Forms;

namespace MinecraftResearchObservation
{
	public partial class PluginDistributedInventoryConfig : Form
	{
		public PluginDistributedInventoryConfig()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
		}
		
		public int _CountPlayers
		{
			get
			{
				return (int)this.numericUpDownCountPlayers.Value;
			}
		}
		
		public string[] _Items
		{
			get
			{
				return this.textBoxItems.Lines;
			}
		}
		
		public string _RestrictedWorldCommand
		{
			get
			{
				return this.textBoxRestrictedWorldCommand.Text;
			}
		}
	}
}
