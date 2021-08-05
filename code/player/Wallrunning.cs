using Sandbox;
using System;

namespace Terryfall
{
	public class Wallrunning
	{
		public static bool wallLeft { get; set; }
		public static bool wallRight { get; set; }
		public static float wallGravity { get; set; } = 10f;
	}
	partial class TPlayer
	{
		public float BodyHeight = 72.0f;
		public float WallDistance = 20.0f;

		public static TraceResult wallLeftTrace;
		public static TraceResult wallRightTrace;

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

			wallLeftTrace = Trace.Ray( startPos, endPos )
				.WorldOnly()
				.Run();

			if ( wallLeftTrace.Hit && GroundEntity == null )
			{
				Wallrunning.wallLeft = true;
				//Log.Info( "Wall on left" );
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

			if ( wallRightTrace.Hit && GroundEntity == null )
			{
				Wallrunning.wallRight = true;
				//Log.Info( "Wall on right" );
			}
			else
			{
				Wallrunning.wallRight = false;
			}
		}
	}
}
