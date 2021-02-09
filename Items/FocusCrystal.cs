using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheddarMod.Items
{
	public class FocusCrystal : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Focus Crystal");
			Tooltip.SetDefault("Any spell can be cast, so long as the caster can maintain focus\nThis crystal ensures the caster always can focus\nIncreases magic stats by 15%\nDisables mana consumption");
		}

		public override void SetDefaults()
		{
			item.width = 25;
			item.height = 25;
			item.rare = ItemRarityID.Lime;
			item.value = 200000;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.manaCost = 0f;
			player.magicDamage += 0.15f;
			player.magicCrit += 15;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "StarRose");
			recipe.AddIngredient(ItemID.CrystalShard, 15);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}