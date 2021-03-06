﻿using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MinecraftServerRCON;

namespace MinecraftResearchObservation
{
	public static class RCONLogic
	{
		private static string minecraftServer = string.Empty;
		private static string minecraftRCONPassword = string.Empty;
		private static RCONClient rconClient = RCONClient.INSTANCE;
		private static bool isRunning = false;
		private static Task currentRunningTask = null;
		
		public static void setMinecraftServer(string minecraftServer)
		{
			RCONLogic.minecraftServer = minecraftServer;
		}
		
		public static void setMinecraftRCONPassword(string minecraftRCONPassword)
		{
			RCONLogic.minecraftRCONPassword = minecraftRCONPassword;
		}
		
		public static void startLogic()
		{
			if(RCONLogic.isRunning)
			{
				return;
			}
			
			RCONLogic.isRunning = true;
			DebugWindow.writeLine(string.Format("Starting the RCONLogic now.\n"));
			RCONLogic.currentRunningTask = Task.Factory.StartNew(() =>
	        {
			    RCONLogic.connect2RCONServer();
              	while(RCONLogic.isRunning)
              	{
              		checkActiveServerConnection();
	              	checkActivePlayers();
	              	Thread.Sleep(TimeSpan.FromMilliseconds(100));
              	}
              	DebugWindow.writeLine(string.Format("The RCONLogic is stopped now.\n"));
			}, TaskCreationOptions.LongRunning);
		}
		
		public static void stopLogic()
		{
			RCONLogic.isRunning = false;
			if(RCONLogic.currentRunningTask != null)
			{
				RCONLogic.currentRunningTask.Wait();
			}
			
			try
			{
				RCONLogic.rconClient.Dispose();
			}
			catch
			{
			}
		}
		
		private static void connect2RCONServer()
		{
			try
		    {
				DebugWindow.writeLine(string.Format("Try to connect...\n"));
				if(RCONLogic.minecraftServer.Contains(":"))
				{
					var startPort = RCONLogic.minecraftServer.IndexOf(':');
					var server = RCONLogic.minecraftServer.Substring(0, startPort);
					var port = RCONLogic.minecraftServer.Replace(server + ":", string.Empty);
					RCONLogic.rconClient.setupStream(server, int.Parse(port), RCONLogic.minecraftRCONPassword);
				}
				else
				{
			    	RCONLogic.rconClient.setupStream(RCONLogic.minecraftServer, password: RCONLogic.minecraftRCONPassword);
				}
				
				RCONLogic.rconClient.fireAndForgetMessage(RCONMessageType.Command, "gamerule commandBlockOutput false");
				RCONLogic.rconClient.fireAndForgetMessage(RCONMessageType.Command, "gamerule logAdminCommands false");
				RCONLogic.rconClient.fireAndForgetMessage(RCONMessageType.Command, "gamerule sendCommandFeedback false");
		    }
		    catch(Exception e)
		    {
		    	DebugWindow.writeLine(string.Format("Exception: {0}\n", e.Message));
				DebugWindow.writeLine(string.Format("Exception: {0}\n", e.StackTrace));
		    	return;
		    }
		}
		
		private static void checkActiveServerConnection()
		{
			var answer = RCONLogic.rconClient.sendMessage(RCONMessageType.Command, @"help");
			if(answer == string.Empty)
			{
				try
				{
					RCONLogic.rconClient.Dispose();
				}
				catch
				{
				}
				
				RCONLogic.connect2RCONServer();
			}
		}
		
		private static void checkActivePlayers()
		{
			try
			{
				var answer = RCONLogic.rconClient.sendMessage(RCONMessageType.Command, @"list");
				if(answer == string.Empty)
				{
					return;
				}
				
				var start = answer.IndexOf(':') + 1;
				var players = answer.Substring(start).Split(',');
				var now = DateTime.UtcNow;
				
				// Call the plugins:
				PluginExecuteCommandsOnce4EachPlayer.executePlugin(RCONLogic.rconClient, players);
				PluginDistributedInventory.executePlugin(RCONLogic.rconClient, players);
				
				foreach(var player in players.Where(n => n != string.Empty))
				{
					var name = player.RemoveColorCodes().Trim();
					
					answer = RCONLogic.rconClient.sendMessage(RCONMessageType.Command, @"mc find " + name);
					if(answer == string.Empty)
					{
						continue;
					}
					
					var posText = answer.RemoveColorCodes();
					var elements = posText.Split(' ');
					var x = int.Parse(elements[5]);
					var y = int.Parse(elements[7]);
					var z = int.Parse(elements[9]);
					var lineResult = string.Format("{4:yyyyMMddHHmmssfff};{0};{1};{2};{3}\n", name, x, y, z, now);
					
					CSVWriter.writeLine(lineResult);
				}
			}
			catch(Exception e)
      		{
      			DebugWindow.writeLine(string.Format("Exception: {0}\n", e.Message));
      			DebugWindow.writeLine(string.Format("Exception: {0}\n", e.StackTrace));
      		}
		}
	}
}
