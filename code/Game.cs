
using Sandbox;
using Sandbox.UI.Construct;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Terryfall
{
	[Library( "terryfall" )]
	public partial class TerryfallGame : Game
	{
		public TerryfallGame()
		{
			if ( IsServer )
			{
				Log.Info( "Server created" );

				// Create HUD
				new THud();
			}

			if ( IsClient )
			{
				Log.Info( "Client Created" );
			}
		}

		/// <summary>
		/// A client has joined the server. Make them a pawn
		/// </summary>
		public override void ClientJoined( Client client )
		{
			base.ClientJoined( client );

			// Give the player their player
			var player = new TPlayer();
			client.Pawn = player;

			player.Respawn();
		}
	}

}
