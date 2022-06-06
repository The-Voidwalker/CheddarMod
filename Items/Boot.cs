using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheddarMod.Items
{
    public class Boot : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Boot.");
            Tooltip.SetDefault("\"Ya got a Boot.\"\nA little greater than the sum of its parts");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 19;
            item.value = 600000;
            item.rare = ItemRarityID.Cyan;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.moveSpeed += 0.16f;
            player.waterWalk = true;
            player.fireWalk = true;
            player.lavaImmune = true;
            player.iceSkate = true;
            player.accFlipper = true;
            player.ignoreWater = true;
            player.accRunSpeed = 6f;
            player.rocketBoots = 3;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FrostsparkBoots);
            recipe.AddIngredient(ItemID.LavaWaders);
            recipe.AddIngredient(ItemID.Flipper);
            recipe.AddIngredient(ItemID.SoulofLight, 3);
            recipe.AddIngredient(ItemID.SoulofNight, 3);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}