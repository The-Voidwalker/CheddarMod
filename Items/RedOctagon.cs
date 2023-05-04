using Terraria;
using Terraria.GameContent.Creative;
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
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 30;
            Item.value = 300000;
            Item.rare = ItemRarityID.Yellow;
            Item.defense = 8;
            Item.accessory = true;
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
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.AnkhShield);
            recipe.AddIngredient(ItemID.FrozenTurtleShell);
            recipe.AddIngredient(ItemID.PocketMirror);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
        }
    }
}