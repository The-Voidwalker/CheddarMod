using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheddarMod.Items
{
	public class Lapis : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lapis Philosophorum");
			Tooltip.SetDefault("\"Perfection achieved!\"");
		}

		public override void SetDefaults()
		{
			item.width = 52;
			item.height = 50;
			item.value = 1000000;
			item.rare = 12;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.armorPenetration += 20;
            player.pStone = true;
            player.starCloak = true;
            player.longInvince = true;
			player.shinyStone = true;
			player.goldRing = true;
			player.coins = true;
			player.discount = true;
			player.lifeRegen += 2;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "HolySpork");
			recipe.AddIngredient(ItemID.ShinyStone);
			recipe.AddIngredient(ItemID.GreedyRing);
			recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
	}
}