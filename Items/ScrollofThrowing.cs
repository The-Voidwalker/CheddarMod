using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheddarMod.Items
{
    public class ScrollofThrowing : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Scroll of Throwing");
            Tooltip.SetDefault("This scroll tell the secret of how to throw things and keep them at the same time.\nProvides boosts to throwing\nThrown stats increased by 15%");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 25;
            Item.height = 25;
            Item.rare = ItemRarityID.Lime;
            Item.value = 400000;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Throwing) += 0.15f;
            player.GetCritChance(DamageClass.Throwing) += 15;

            CheddarModPlayer modPlayer = player.GetModPlayer<CheddarModPlayer>();
            modPlayer.scroll = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod, "PointyPocket");
            recipe.AddIngredient(ItemID.Book, 5);
            recipe.AddTile(TileID.CrystalBall);
            recipe.Register();
        }
    }
}