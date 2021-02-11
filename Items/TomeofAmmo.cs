using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheddarMod.Items
{
    public class TomeofAmmo : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tome of Ammo");
            Tooltip.SetDefault("This tome contains instructions for conjuring ammunition from nothing\nIncreases ranged stats by 15%, and you preserve all ammo");
        }

        public override void SetDefaults()
        {
            item.width = 25;
            item.height = 25;
            item.rare = ItemRarityID.Lime;
            item.value = 20000;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.rangedDamage += 0.15f;
            player.rangedCrit += 15;

            CheddarModPlayer modPlayer = player.GetModPlayer<CheddarModPlayer>();
            modPlayer.tome = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, "AmmomancerPouch");
            recipe.AddIngredient(ItemID.EndlessQuiver);
            recipe.AddIngredient(ItemID.EndlessMusketPouch);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}