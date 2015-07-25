using System;
using System.Collections.Generic;
using MinecraftServerRCON;
using System.Threading;
using System.Linq;

namespace MinecraftResearchObservation
{
	public static class PluginExecuteCommandsOnce4EachPlayer
	{
		private static readonly object threadLock = new object();
		private static bool pluginIsActive = false;
		private static Dictionary<string, DateTime> knownPlayers = new Dictionary<string, DateTime>();
		private static string[] commands = new string[0];
		
		public static bool executePlugin(RCONClient rconClient, IEnumerable<string> players)
		{
			Monitor.Enter(threadLock);
			
			try
			{
				if(!pluginIsActive)
				{
					return false;
				}
				
				// Update the time stamps for the known players:
				foreach (var playerName in players.Where(player => player != string.Empty))
				{
					var name = playerName.RemoveColorCodes().Trim();
					if(!knownPlayers.ContainsKey(name))
					{
						foreach(var command in commands)
						{
							rconClient.fireAndForgetMessage(RCONMessageType.Command, command.Replace("$NAME$", name));
						}
					}
					
					knownPlayers[name] = DateTime.UtcNow;
				}
				
				// Remove dead entries:
				var dead = new List<string>(knownPlayers.Keys.Where(n => (DateTime.UtcNow - knownPlayers[n]).TotalSeconds >= 2));
				foreach(var d in dead)
				{
					knownPlayers.Remove(d);
				}
				
				return true;
			}
			finally
			{
				Monitor.Exit(threadLock);
			}
		}

		public static string[] Commands
		{
			get
			{
				return commands;
			}
			
			set
			{
				Monitor.Enter(threadLock);
				try
				{
					commands = value;
				}
				finally
				{
					Monitor.Exit(threadLock);
				}
			}
		}
		
		public static bool PluginIsActive
		{
			get
			{
				return pluginIsActive;
			}
			
			set
			{
				Monitor.Enter(threadLock);
				try
				{
					pluginIsActive = value;
				}
				finally
				{
					Monitor.Exit(threadLock);
				}
			}
		}
	}
}
