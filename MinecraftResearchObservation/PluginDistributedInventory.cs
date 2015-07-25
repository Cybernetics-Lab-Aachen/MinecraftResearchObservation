using System;
using MinecraftServerRCON;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using NETools.Random;

namespace MinecraftResearchObservation
{
	public static class PluginDistributedInventory
	{
		private static readonly object threadLock = new object();
		private static bool pluginIsActive = false;
		private static int destinationCountPlayers = 2;
		private static string restrictedWorldCommand = string.Empty;
		private static string[] items = new string[0];
		private static bool allPlayersPresent = false;
		
		public static bool executePlugin(RCONClient rconClient, IEnumerable<string> players)
		{
			Monitor.Enter(threadLock);
			
			try
			{
				if(!pluginIsActive)
				{
					return false;
				}
				
				var isRestrictedWorld = rconClient.sendMessage(RCONMessageType.Command, restrictedWorldCommand).RemoveColorCodes().Trim() == string.Empty;
				if(!isRestrictedWorld)
				{				
					// Reset the status if a player gets lost:
					if (players.Count(n => n != string.Empty) != destinationCountPlayers)
					{
						allPlayersPresent = false;
					}
		
					// If not all players are present, delete the inventories:
					if (!allPlayersPresent && players.Count(n => n != string.Empty) != destinationCountPlayers && players.Count(n => n != string.Empty) > 0)
					{
						foreach (var player in players.Where(n => n != string.Empty))
						{
							var name = player.RemoveColorCodes().Trim();
							rconClient.sendMessage(RCONMessageType.Command, @"clear " + name);
						}
		
						allPlayersPresent = false;
						return true;
					}
		
					// Now, all players are in place:
					if (items.Length > 0 && !allPlayersPresent)
					{
						allPlayersPresent = true;
		
						//
						// First: Clear all inventories (important for the last player who was new)
						//
						foreach (var player in players.Where(n => n != string.Empty))
						{
							var name = player.RemoveColorCodes().Trim();
							rconClient.sendMessage(RCONMessageType.Command, @"clear " + name);
						}
		
						//
						// Second: Distribute the items
						//
						
						// Get the right list of items which matches the count of players:
						var rightItemList = items.Skip(items.Length % destinationCountPlayers).ToArray();
						
						// Memorise the already used items:
						var usedItems = new List<int>();
						
						for (var n = 0; n < rightItemList.Length / destinationCountPlayers; n++)
						{
							foreach (var playerName in players.Where(player => player != string.Empty))
							{
								// Find the next matching number i.e. item's position:
								var nextNumber = 0;
								while (true)
								{
									nextNumber = BetterRND.INSTANCE.nextInt(0, rightItemList.Length);
									if (!usedItems.Contains(nextNumber))
									{
										usedItems.Add(nextNumber);
										break;
									}
									else
									{
										Thread.Sleep(1);
										continue;
									}
								}
								
								// Get the item:
								var item = " " + rightItemList[nextNumber];
								
								// Build the command:
								var item4Player = "give " + playerName.RemoveColorCodes().Trim() + item;
								
								// Send the command:
								rconClient.fireAndForgetMessage(RCONMessageType.Command, item4Player);
							}
						}
					}
				}
				
				return true;
			}
			finally
			{
				Monitor.Exit(threadLock);
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

		public static string[] Items
		{
			get
			{
				return items;
			}
			
			set
			{
				Monitor.Enter(threadLock);
				try
				{
					items = value;
				}
				finally
				{
					Monitor.Exit(threadLock);
				}
			}
		}
		
		public static string RestrictedWorldCommand
		{
			get
			{
				return restrictedWorldCommand;
			}
			
			set
			{
				Monitor.Enter(threadLock);
				try
				{
					restrictedWorldCommand = value;
				}
				finally
				{
					Monitor.Exit(threadLock);
				}
			}
		}
		
		public static int DestinationCountPlayers
		{
			get
			{
				return destinationCountPlayers;
			}
			
			set
			{
				Monitor.Enter(threadLock);
				try
				{
					destinationCountPlayers = value;
				}
				finally
				{
					Monitor.Exit(threadLock);
				}
			}
		}
	}
}
