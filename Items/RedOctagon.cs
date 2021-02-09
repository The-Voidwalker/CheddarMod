using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheddarMod.Items
{
    public class RedOctagon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Red Octagon");
            Tooltip.SetDefault("Provides immunity to knockback and a large set of debuffs\nReduces damage taken by 15%\n\"Though the symbols on it have faded, its stopping power is still immense.\"");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 30;
            item.value = 300000;
            item.rare = ItemRarityID.Yellow;
            item.defense = 8;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.buffImmune[46] = true;
            player.buffImmune[47] = true;
            player.noKnockback = true;
            player.fireWalk = true;
            player.buffImmune[33] = true;
            player.buffImmune[36] = true;
            player.buffImmune[30] = true;
            player.buffImmune[20] = true;
            player.buffImmune[32] = true;
            player.buffImmune[31] = true;
            player.buffImmune[35] = true;
            player.buffImmune[23] = true;
            player.buffImmune[22] = true;
            player.buffImmune[156] = true;
            player.endurance += 0.15f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.AnkhShield);
            recipe.AddIngredient(ItemID.FrozenTurtleShell);
            recipe.AddIngredient(ItemID.PocketMirror);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}