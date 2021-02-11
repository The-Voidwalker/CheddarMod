using Terraria.ID;
using Terraria.ModLoader;

namespace CheddarMod.Items
{
    public class RecoveryPotLarg : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Greater Recovery Potion");
            Tooltip.SetDefault("Recovers 45% of your max hp over 30 seconds");
        }

        public override void SetDefaults()
        {
            item.height = 20;
            item.width = 20;
            item.rare = ItemRarityID.Green;
            item.value = 1000;
            item.buffType = mod.BuffType("RecoveryFast");
            item.buffTime = 1800;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 10;
            item.useTime = 10;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, "RecoveryPotSmol", 4);
            recipe.AddIngredient(ItemID.FragmentSolar);
            recipe.AddIngredient(ItemID.FragmentNebula);
            recipe.AddIngredient(ItemID.FragmentVortex);
            recipe.AddIngredient(ItemID.FragmentStardust);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this, 4);
            recipe.AddRecipe();
        }
    }
}