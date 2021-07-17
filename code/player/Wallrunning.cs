using Sandbox;
using System;

namespace Terryfall
{
	public class Wallrunning
	{
		public static bool wallLeft { get; set; }
		public static bool wallRight { get; set; }
	}
	partial class TerryfallPlayer
	{
		public float BodyHeight = 72.0f;
		public float WallDistance = 35.0f;

		public void CheckforWallrun()
		{
			if ( !IsClient )
				return;

			WallLeftTrace();
			WallRightTrace();
		}

		void WallLeftTrace()
		{
			var startPos = EyePos;
			var endPos = EyePos + EyeRot.Left * WallDistance;

			var wallLeftTrace = Trace.Ray( startPos, endPos )
				.WorldOnly()
				.Run();

			if ( wallLeftTrace.Hit )
			{
				Wallrunning.wallLeft = true;
				Log.Info( "Wall on left" );
			}
			else
			{
				Wallrunning.wallLeft = false;
			}

		}

		void WallRightTrace()
		{
			var startPos = EyePos;
			var endPos = EyePos + EyeRot.Right * WallDistance;
			var wallRightTrace = Trace.Ray( startPos, endPos )
				.WorldOnly()
				.Run();

			if ( wallRightTrace.Hit )
			{
				Wallrunning.wallRight = true;
				Log.Info( "Wall on right" );
			}
			else
			{
				Wallrunning.wallRight = false;
			}
		}
	}
}
