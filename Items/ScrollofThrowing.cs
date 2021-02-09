using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheddarMod.Items
{
	public class ScrollofThrowing : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Scroll of Throwing");
			Tooltip.SetDefault("This scroll tell the secret of how to throw things and keep them at the same time.\nProvides boosts to throwing\nThrown stats increased by 15%");
		}

		public override void SetDefaults()
		{
			item.width = 25;
			item.height = 25;
			item.rare = ItemRarityID.Lime;
			item.value = 400000;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.thrownDamage += 0.15f;
			player.thrownCrit += 15;

			CheddarModPlayer modPlayer = player.GetModPlayer<CheddarModPlayer>();
			modPlayer.scroll = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "PointyPocket");
			recipe.AddIngredient(ItemID.Book, 5);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}