using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheddarMod.Items
{
    public class HolySpork : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Holy Spork");
            Tooltip.SetDefault("All Hail The Spork!");
        }

        public override void SetDefaults()
        {
            item.width = 12;
            item.height = 38;
            item.value = 600000;
            item.rare = 7;
            item.lifeRegen = 2;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.armorPenetration += 10;
            player.pStone = true;
            player.starCloak = true;
            player.longInvince = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StarVeil);
            recipe.AddIngredient(ItemID.CharmofMyths);
            recipe.AddIngredient(ItemID.SharkToothNecklace);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}