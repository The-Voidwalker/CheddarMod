using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheddarMod.Items
{
	public class GoldenSigil : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Golden Sigil");
			Tooltip.SetDefault("The mark of a great warrior");
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 32;
			item.value = 500000;
			item.rare = 10;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.manaMagnet = true;
			player.magicDamage += 0.15f;
			player.magicCrit += 10;
			player.kbGlove = true;
			player.meleeSpeed += 0.1f;
			player.meleeDamage += 0.15f;
			player.meleeCrit += 10;
			player.magmaStone = true;
			player.scope = true;
			player.rangedCrit += 10;
			player.rangedDamage += 0.15f;
			player.magicQuiver = true;
			player.arrowDamage += 0.15f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CelestialEmblem);
			recipe.AddIngredient(ItemID.FireGauntlet);
			recipe.AddIngredient(ItemID.SniperScope);
			recipe.AddIngredient(ItemID.MagicQuiver);
			recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
	}
}