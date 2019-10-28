using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheddarMod.Items
{
	public class AmmomancerPouch : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ammomancer's Pouch");
			Tooltip.SetDefault("Reach beyond the world to never run out of ammunition\nProvides a small boost to ranged abilities");
		}

		public override void SetDefaults()
		{
			item.width = 29;
			item.height = 36;
			item.value = 50000;
			item.rare = 5;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.rangedDamage += 0.05f;
			player.rangedCrit += 5;

			CheddarModPlayer modPlayer = player.GetModPlayer<CheddarModPlayer>();
			modPlayer.ammomancer = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.WoodenArrow, 999);
			recipe.AddIngredient(ItemID.MusketBall, 999);
			recipe.AddIngredient(ItemID.Lens, 2);
			recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
	}
}