using Sandbox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terryfall
{
	public class FirstPersonCamera : Camera
	{
		public float walkingFov = 100.0f;
		public float wallrunningFov = 120.0f;
		public float FovSpeed = 10.0f;

		Vector3 lastPos;
		Rotation tilt;

		public override void Activated()
		{
			var pawn = Local.Pawn;
			if ( pawn == null ) return;

			Pos = pawn.EyePos;
			Rot = pawn.EyeRot;

			lastPos = Pos;
		}

		public override void Update()
		{
			var pawn = Local.Pawn;
			if ( pawn == null ) return;

			var eyePos = pawn.EyePos;
			if ( eyePos.Distance( lastPos ) < 300 ) // TODO: Tweak this, or add a way to invalidate lastpos when teleporting
			{
				Pos = Vector3.Lerp( eyePos.WithZ( lastPos.z ), eyePos, 20.0f * Time.Delta );
			}
			else
			{
				Pos = eyePos;
			}

			Rot = pawn.EyeRot;

			if(Wallrunning.wallLeft || Wallrunning.wallRight)
			{
				FieldOfView = MathX.LerpTo( FieldOfView, wallrunningFov, FovSpeed * Time.Delta );
			}

			if ( Wallrunning.wallLeft )
			{
				Log.Info( "cool running on left good job" );
			}
			else if ( Wallrunning.wallRight )
			{
				Log.Info( "cool running on right good job" );
			}
			else
			{
				FieldOfView = MathX.LerpTo( FieldOfView, walkingFov, FovSpeed * Time.Delta );
			}

			Viewer = pawn;
			lastPos = Pos;
		}
	}
}
