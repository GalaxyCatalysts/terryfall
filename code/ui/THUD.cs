using Sandbox;
using Sandbox.UI;

//
// You don't need to put things in a namespace, but it doesn't hurt.
//
namespace Terryfall
{
	/// <summary>
	/// This is the HUD entity. It creates a RootPanel clientside, which can be accessed
	/// via RootPanel on this entity, or Local.Hud.
	/// </summary>
	public partial class THudEntity : HudEntity<RootPanel>
	{
		public THudEntity()
		{
			if ( IsClient )
			{
				RootPanel.SetTemplate( "/ui/THUD.html" );
			}
		}
	}

	[Library]
	public partial class THUD : HudEntity<RootPanel>
	{
		public THUD()
		{
			if ( !IsClient )
				return;

			RootPanel.StyleSheet.Load( "/ui/THUD.scss" );

			RootPanel.AddChild<ChatBox>();
			RootPanel.AddChild<NameTags>();
			RootPanel.AddChild<VoiceList>();
			RootPanel.AddChild<Scoreboard<ScoreboardEntry>>();
		}
	}



}
