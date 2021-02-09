using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace CheddarMod.Items
{
	public class CarvedBone : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Carved Bone");
			Tooltip.SetDefault("This bone is carven with mystic runes.\nIncreases maximum minions by 3, but reduces minion damage by 20%");
		}

		public override void SetDefaults()
		{
			item.width = 25;
			item.height = 25;
			item.rare = ItemRarityID.LightRed;
			item.value = 30000;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.maxMinions += 3;
			player.minionDamage -= 0.2f;
		}
	}
}