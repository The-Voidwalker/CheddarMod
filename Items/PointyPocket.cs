using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheddarMod.Items
{
	public class PointyPocket : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pocket of Pointy Things");
			Tooltip.SetDefault("Provides a boost to throwing abilities\nThrown items are never consumed");
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 22;
			item.value = 50000;
			item.rare = 5;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.thrownDamage += 0.05f;
            player.thrownCrit += 5;

			CheddarModPlayer modPlayer = player.GetModPlayer<CheddarModPlayer>();
			modPlayer.pocket = true;
		}

		public override void AddRecipes()
		{
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ThrowingKnife, 100);
			recipe.AddIngredient(ItemID.Shuriken, 100);
			recipe.AddIngredient(ItemID.Leather, 5);
			recipe.AddIngredient(ItemID.Gel, 25);
			recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
	}
}