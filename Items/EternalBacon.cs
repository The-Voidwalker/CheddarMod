using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheddarMod.Items
{
    public class EternalBacon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eternal Bacon");
            Tooltip.SetDefault("Praise the ETERNAL BACON!\nALL PRAISE!");
        }

        public override void SetDefaults()
        {
            item.UseSound = SoundID.Item2;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useTurn = true;
            item.useAnimation = 17;
            item.useTime = 17;
            // item.maxStack = 1;
            item.consumable = false;
            item.width = 10;
            item.height = 10;
            item.buffType = 26;
            item.buffTime = 216000;
            item.rare = ItemRarityID.Green;
            item.value = 10000;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bacon, 30);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}