using Terraria;
using Terraria.GameContent.Creative;
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
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 18;
            Item.value = 1000000;
            Item.rare = ItemRarityID.Purple;
            Item.accessory = true;
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
            player.accRunSpeed = 9f;
            player.rocketBoots = 3;
            player.runAcceleration *= 2f;

            player.hasJumpOption_Cloud = true;
            player.hasJumpOption_Sandstorm = true;
            player.hasJumpOption_Blizzard = true;
            player.hasJumpOption_Fart = true;
            player.hasJumpOption_Sail = true;
            player.jumpBoost = true;
            player.noFallDmg = true;
            player.autoJump = true;
            player.jumpSpeedBoost = 3.6f;

            CheddarModPlayer modPlayer = player.GetModPlayer<CheddarModPlayer>();
            modPlayer.yeet = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod, "Boot");
            recipe.AddIngredient(ItemID.SoulofFlight, 7);
            recipe.AddIngredient(ItemID.BundleofBalloons);
            recipe.AddIngredient(ItemID.FrogLeg);
            recipe.AddIngredient(ItemID.SoulofMight);
            recipe.AddIngredient(ItemID.SoulofSight);
            recipe.AddIngredient(ItemID.SoulofFright);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
        }
    }
}