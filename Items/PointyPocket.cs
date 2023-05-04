using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheddarMod.Items
{
    public class PointyPocket : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pocket of Pointy Things");
            Tooltip.SetDefault("Provides a boost to throwing abilities\nThrown items consumed less.");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 22;
            Item.value = 50000;
            Item.rare = ItemRarityID.Pink;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Throwing) += 0.05f;
            player.GetCritChance(DamageClass.Throwing) += 5;

            CheddarModPlayer modPlayer = player.GetModPlayer<CheddarModPlayer>();
            modPlayer.pocket = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod, "RadiantOoze");
            recipe.AddIngredient(ItemID.ThrowingKnife, 100);
            recipe.AddIngredient(ItemID.Shuriken, 100);
            recipe.AddIngredient(ItemID.Leather, 5);
            recipe.AddIngredient(ItemID.Gel, 25);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
        }
    }
}