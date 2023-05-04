using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheddarMod.Items
{
    public class Regenerator : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Regenerator");
            Tooltip.SetDefault("Increases life regeneration by 1\nBoosts healing potion effectiveness by 20%");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.value = 20000;
            Item.rare = ItemRarityID.LightRed;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            CheddarModPlayer mPlayer = player.GetModPlayer<CheddarModPlayer>();
            mPlayer.hBoost = 1.2f;
            player.lifeRegen += 1;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.LifeCrystal);
            recipe.AddIngredient(ItemID.BottledHoney, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}