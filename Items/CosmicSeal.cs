using Terraria;
using Terraria.ModLoader;

namespace CheddarMod.Items
{
	public class CosmicSeal : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cosmic Seal");
			Tooltip.SetDefault("A little bit of eldrich power goes a long way.\nDisables potion consumption.\nOn death, the player has a 10% chance to quick-heal instead of die.\nThis effect ignores potion sickness that was not caused by itself.");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.value = 1200000;
			item.rare = 12;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			CheddarModPlayer modPlayer = player.GetModPlayer<CheddarModPlayer>();
			modPlayer.potionSaver = true;
			modPlayer.healBeforeDeath = true;
		}
	}
}
