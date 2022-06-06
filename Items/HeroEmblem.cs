using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheddarMod.Items
{
    public class HeroEmblem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hero's Emblem");
            Tooltip.SetDefault("Its power has been restored.\nIncreases Melee damage and crit by 15% and Melee speed by 10%.\nMelee weapons auto swing");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.value = 50000;
            item.rare = ItemRarityID.Pink;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.meleeDamage += 0.15f;
            player.meleeCrit += 15;
            player.meleeSpeed += 0.1f;

            CheddarModPlayer modPlayer = player.GetModPlayer<CheddarModPlayer>();
            modPlayer.hero = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipeGold = new ModRecipe(mod);
            recipeGold.AddIngredient(mod, "WornEmblem");
            recipeGold.AddRecipeGroup("Cheddar:GoldBars");
            recipeGold.AddTile(TileID.MythrilAnvil);
            recipeGold.SetResult(this);
            recipeGold.AddRecipe();
        }
    }
}