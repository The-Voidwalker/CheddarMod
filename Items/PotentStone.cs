using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheddarMod.Items
{
    public class PotentStone : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stone of Potency");
            Tooltip.SetDefault("Increases health regeneration by 1\nBoosts healing potion effectiveness by 20%\nIncreases potion duration by 35%");
        }

        public override void SetDefaults()
        {
            item.height = 20;
            item.width = 20;
            item.rare = ItemRarityID.Pink;
            item.value = 30000;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            CheddarModPlayer mPlayer = player.GetModPlayer<CheddarModPlayer>();
            mPlayer.hBoost = 1.3f;
            mPlayer.bBoost = 1.35f;
            player.lifeRegen += 1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, "Regenerator");
            recipe.AddIngredient(ItemID.SoulofLight, 2);
            recipe.AddRecipeGroup("Cheddar:CobaltOres", 3);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}