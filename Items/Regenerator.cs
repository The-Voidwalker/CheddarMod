using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheddarMod.Items
{
	public class Regenerator : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Regenerator");
			Tooltip.SetDefault("Increases life regeneration by 1\nBoosts healing potion effectiveness by 20%");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.value = 20000;
			item.rare = ItemRarityID.LightRed;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			CheddarModPlayer mPlayer = player.GetModPlayer<CheddarModPlayer>();
			mPlayer.hBoost = 1.2f;
			player.lifeRegen += 1;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LifeCrystal);
			recipe.AddIngredient(ItemID.BottledHoney, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}