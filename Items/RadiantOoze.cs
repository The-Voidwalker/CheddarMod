using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace CheddarMod.Items
{
	public class RadiantOoze : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Radiant Ooze");
			Tooltip.SetDefault("A small mass of gel with mystical properties.\nPerhaps it can be used for something?");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.rare = ItemRarityID.Orange;
			item.value = 6000;
		}
	}
}
