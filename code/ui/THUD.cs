using Sandbox;
using Sandbox.UI;

namespace Terryfall
{
	[Library]
	public partial class THud : HudEntity<RootPanel>
	{
		public static Panel MainPanel;

		public THud()
		{
			if ( !IsClient )
				return;

			RootPanel.SetTemplate( "/ui/HTMLPanel.html" );
			
			MainPanel = RootPanel.AddChild<MainPanel>();

			RootPanel.AddChild<ChatBox>();
			RootPanel.AddChild<NameTags>();
			RootPanel.AddChild<VoiceList>();
			RootPanel.AddChild<Scoreboard<ScoreboardEntry>>();
		}
	}
}
