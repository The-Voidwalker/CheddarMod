using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheddarMod.Items
{
    public class AmmomancerPouch : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ammomancer's Pouch");
            Tooltip.SetDefault("Reduced chance to consume ammunition\nBoosts ranged damage and crit chance by 5%.");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 29;
            Item.height = 36;
            Item.value = 50000;
            Item.rare = ItemRarityID.Pink;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Ranged) += 0.05f;
            player.GetCritChance(DamageClass.Ranged) += 5;

            CheddarModPlayer modPlayer = player.GetModPlayer<CheddarModPlayer>();
            modPlayer.ammomancer = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod, "EngravedLens");
            recipe.AddIngredient(ItemID.WoodenArrow, 999);
            recipe.AddIngredient(ItemID.MusketBall, 999);
            recipe.AddIngredient(ItemID.Lens, 2);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
        }
    }
}