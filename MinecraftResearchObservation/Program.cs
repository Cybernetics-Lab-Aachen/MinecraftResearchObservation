using System;
using System.Windows.Forms;

namespace MinecraftResearchObservation
{
	internal sealed class Program
	{
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			
			using(var d = new BaseInformation())
			{
				d.ShowDialog();
				Application.Run(new MainForm(d._DestinationFolder, d._MetaInformation, d._MinecraftServer, d._MinecraftRCONPassword));
			}
		}
		
	}
}
