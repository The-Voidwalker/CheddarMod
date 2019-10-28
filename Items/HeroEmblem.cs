using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheddarMod.Items
{
	public class HeroEmblem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hero's Emblem");
			Tooltip.SetDefault("Grants a small boost to melee abilities\nMelee weapons auto swing");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 26;
			item.value = 50000;
			item.rare = 5;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.meleeDamage += 0.05f;
			player.meleeCrit += 5;

			CheddarModPlayer modPlayer = player.GetModPlayer<CheddarModPlayer>();
			modPlayer.hero = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipeGold = new ModRecipe(mod);
			recipeGold.AddIngredient(ItemID.GoldBar, 15);
			recipeGold.AddTile(TileID.TinkerersWorkbench);
            recipeGold.SetResult(this);
            recipeGold.AddRecipe();

			ModRecipe recipePlat = new ModRecipe(mod);
			recipePlat.AddIngredient(ItemID.PlatinumBar, 15);
			recipePlat.AddTile(TileID.TinkerersWorkbench);
            recipePlat.SetResult(this);
            recipePlat.AddRecipe();
		}
	}
}