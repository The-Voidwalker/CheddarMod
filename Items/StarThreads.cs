using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheddarMod.Items
{
    public class StarThreads : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star Threads");
            Tooltip.SetDefault("\"Run among the stars!\"");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 18;
            item.value = 1000000;
            item.rare = ItemRarityID.Purple;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.moveSpeed += 1.28f;
            player.waterWalk = true;
            player.fireWalk = true;
            player.lavaImmune = true;
            player.iceSkate = true;
            player.accFlipper = true;
            player.ignoreWater = true;
            player.accRunSpeed = 12f;
            player.rocketBoots = 3;
            player.runAcceleration *= 2f;

            player.doubleJumpCloud = true;
            player.doubleJumpSandstorm = true;
            player.doubleJumpBlizzard = true;
            player.doubleJumpFart = true;
            player.doubleJumpSail = true;
            player.jumpBoost = true;
            player.noFallDmg = true;
            player.autoJump = true;
            player.jumpSpeedBoost = 3.6f;

            CheddarModPlayer modPlayer = player.GetModPlayer<CheddarModPlayer>();
            modPlayer.yeet = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, "Boot");
            recipe.AddIngredient(mod, "YeetForce");
            recipe.AddIngredient(ItemID.SoulofMight);
            recipe.AddIngredient(ItemID.SoulofSight);
            recipe.AddIngredient(ItemID.SoulofFright);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}