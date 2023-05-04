using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheddarMod.Items
{
    public class RecoveryPot : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Recovery Potion");
            Tooltip.SetDefault("Recovers 30% of your max hp over 60 seconds");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;
        }

        public override void SetDefaults()
        {
            Item.height = 20;
            Item.width = 20;
            Item.rare = ItemRarityID.Pink;
            Item.value = 5000;
            Item.buffType = Mod.Find<ModBuff>("Recovery").Type;
            Item.buffTime = 3600;
            Item.useStyle = ItemUseStyleID.EatFood;
            Item.useAnimation = 10;
            Item.useTime = 10;
            Item.consumable = true;
            Item.maxStack = 30;
            Item.UseSound = SoundID.Item3;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod, "RecoveryPotSmol");
            recipe.AddIngredient(ItemID.Mushroom);
            recipe.AddIngredient(ItemID.GlowingMushroom);
            recipe.AddTile(TileID.Bottles);
            recipe.Register();
        }
    }
}