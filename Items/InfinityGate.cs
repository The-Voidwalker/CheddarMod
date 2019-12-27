using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheddarMod.Items
{
	public class InfinityGate : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Infinity Gate");
			Tooltip.SetDefault("\"The path to infinite power\"");
		}

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 28;
			item.value = 1000000;
			item.rare = 12;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.manaCost = 0f;
			player.manaMagnet = true;
			player.magicDamage += 0.25f;
			player.magicCrit += 20;
			player.kbGlove = true;
			player.meleeSpeed += 0.2f;
			player.meleeDamage += 0.25f;
			player.meleeCrit += 20;
			player.magmaStone = true;
			player.rangedCrit += 20;
			player.rangedDamage += 0.25f;
			player.magicQuiver = true;
			player.arrowDamage += 0.2f;
			player.accMerman = true;
			player.hideMerman = true;
			player.wolfAcc = true;
			player.hideWolf = true;
			player.lifeRegen += 5;
			player.pickSpeed -= 0.25f;
			player.minionDamage += 0.25f;
			player.minionKB += 0.75f;
			player.thrownDamage += 0.25f;
			player.thrownCrit += 20;

			CheddarModPlayer modPlayer = player.GetModPlayer<CheddarModPlayer>();
			modPlayer.stuff = true;
			modPlayer.trueHero = true;
			modPlayer.scope = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "AmmomancerPouch");
			recipe.AddIngredient(mod, "HeroEmblem");
			recipe.AddIngredient(mod, "PointyPocket");
			recipe.AddIngredient(mod, "StarRose");
			recipe.AddIngredient(mod, "GoldenSigil");
			recipe.AddIngredient(ItemID.CelestialShell);
			recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
	}
}