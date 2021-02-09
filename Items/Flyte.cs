using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheddarMod.Items
{
	[AutoloadEquip(EquipType.Wings)]
	public class Flyte : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Flyte");
			Tooltip.SetDefault("Flight Eternal\nHover for even more speed!");
		}

		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 38;
			item.value = 1000000;
			item.rare = 12;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.moveSpeed += 2.56f;
            player.waterWalk = true;
            player.fireWalk = true;
            player.lavaImmune = true;
            player.iceSkate = true;
            player.accFlipper = true;
            player.ignoreWater = true;
            player.accRunSpeed = 16f;
            player.rocketBoots = 3;
			player.runAcceleration *= 4f;

            player.jumpBoost = true;
            player.noFallDmg = true;
            player.autoJump = true;
            player.jumpSpeedBoost = 6f;
			player.wingTimeMax = 240;

			player.blackBelt = true;
			player.dash = 1;
			player.spikedBoots = 2;

            CheddarModPlayer modPlayer = player.GetModPlayer<CheddarModPlayer>();
			modPlayer.flyte = true;
		}

		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising, ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
		{
			if(player.controlDown && player.controlJump)
			{
				ascentWhenRising = 0.2f;
				ascentWhenFalling = 0.2f;
				maxAscentMultiplier = 1E-05f;
				maxCanAscendMultiplier = 1E-05f;
				constantAscend = 0.14f;
			}
			else
			{
				ascentWhenFalling = 0.8f;
				ascentWhenRising = 0.2f;
				maxCanAscendMultiplier = 4f;
				maxAscentMultiplier = 2f;
				constantAscend = 0.14f;
			}
		}

		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
		{
			if(player.controlDown && player.controlJump)
			{
				speed = 30f;
				acceleration *= 7f;
			}
			else
			{
				speed = 10f;
				acceleration *= 3f;
			}
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MasterNinjaGear);
			recipe.AddIngredient(mod, "StarThreads");
			recipe.AddIngredient(ItemID.FragmentVortex, 5);
			recipe.AddIngredient(ItemID.FragmentSolar, 5);
			recipe.AddIngredient(ItemID.FragmentNebula, 5);
			recipe.AddIngredient(ItemID.FragmentStardust, 5);
			recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
	}
}