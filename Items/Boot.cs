using Terraria;
using Terraria.GameContent.Creative;
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
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 19;
            Item.value = 600000;
            Item.rare = ItemRarityID.Cyan;
            Item.accessory = true;
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
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.FrostsparkBoots);
            recipe.AddIngredient(ItemID.LavaWaders);
            recipe.AddIngredient(ItemID.Flipper);
            recipe.AddIngredient(ItemID.SoulofLight, 3);
            recipe.AddIngredient(ItemID.SoulofNight, 3);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}