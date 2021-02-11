using Terraria.ID;
using Terraria.ModLoader;

namespace CheddarMod.Items
{
    public class RecoveryPotSmol : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lesser Recovery Potion");
            Tooltip.SetDefault("Recovers 15% of your max hp over 30 seconds");
        }

        public override void SetDefaults()
        {
            item.height = 20;
            item.width = 20;
            item.rare = ItemRarityID.Green;
            item.value = 1000;
            item.buffType = mod.BuffType("Recovery");
            item.buffTime = 1800;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 10;
            item.useTime = 10;
            item.consumable = true;
            item.maxStack = 30;
            item.UseSound = SoundID.Item3;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LesserHealingPotion, 2);
            recipe.AddIngredient(ItemID.RegenerationPotion);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this, 2);
            recipe.AddRecipe();
        }
    }
}