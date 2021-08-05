using Sandbox;
using Sandbox.UI;

namespace Terryfall
{
	public partial class THudEntity : HudEntity<RootPanel>
	{
		public THudEntity()
		{
			if ( IsClient )
			{
				RootPanel.SetTemplate( "/ui/THud.html" );
			}
		}
	}

	[Library]
	public partial class THud : HudEntity<RootPanel>
	{
		public THud()
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
