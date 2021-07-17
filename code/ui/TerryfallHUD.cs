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
	public partial class TerryfallHudEntity : Sandbox.HudEntity<RootPanel>
	{
		public TerryfallHudEntity()
		{
			if ( IsClient )
			{
				RootPanel.SetTemplate( "/ui/terryfallhud.html" );
			}
		}
	}



}
