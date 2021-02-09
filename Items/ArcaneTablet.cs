using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheddarMod.Items
{
	public class ArcaneTablet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Arcane Tablet");
			Tooltip.SetDefault("Grants power over others, provided that you can summon them\nMax minions increased by 4\nMinion damage increased by 15%");
		}

		public override void SetDefaults()
		{
			item.width = 25;
			item.height = 25;
			item.rare = ItemRarityID.Yellow;
			item.value = 140000;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.maxMinions += 4;
			player.minionDamage += 0.15f;
			player.minionKB += 1;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "CarvedBone");
			recipe.AddIngredient(ItemID.SoulofNight, 9);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}