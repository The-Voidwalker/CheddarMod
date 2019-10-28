using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheddarMod.Items
{
    public class YeetForce : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Lift");
            Tooltip.SetDefault("Infinite jumping and no repercussions");
        }

        public override void SetDefaults()
        {
            item.width = 9;
            item.height = 25;
            item.value = 500000;
            item.rare = 8;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.doubleJumpCloud = true;
            player.doubleJumpSandstorm = true;
            player.doubleJumpBlizzard = true;
            player.doubleJumpFart = true;
            player.doubleJumpSail = true;
            player.jumpBoost = true;
            player.noFallDmg = true;
            player.autoJump = true;
            player.jumpSpeedBoost = 2.4f;
            player.moveSpeed += 0.05f;

            CheddarModPlayer modPlayer = player.GetModPlayer<CheddarModPlayer>();
            modPlayer.yeet = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BundleofBalloons);
            recipe.AddIngredient(ItemID.FartInABalloon);
            recipe.AddIngredient(ItemID.SharkronBalloon);
            recipe.AddIngredient(ItemID.FrogLeg);
            recipe.AddIngredient(ItemID.SoulofFlight, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}