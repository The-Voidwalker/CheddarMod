using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheddarMod.Items
{
	public class RecoveryPot : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Recovery Potion");
			Tooltip.SetDefault("Recovers 30% of your max hp over 60 seconds");
		}

		public override void SetDefaults()
		{
			item.height = 20;
			item.width = 20;
			item.rare = ItemRarityID.Pink;
			item.value = 5000;
			item.buffType = mod.BuffType("Recovery");
			item.buffTime = 3600;
			item.useStyle = ItemUseStyleID.EatingUsing;
			item.useAnimation = 10;
			item.useTime = 10;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "RecoveryPotSmol");
			recipe.AddIngredient(ItemID.Mushroom);
			recipe.AddIngredient(ItemID.GlowingMushroom);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}