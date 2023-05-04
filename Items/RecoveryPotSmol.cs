using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheddarMod.Items
{
    public class RecoveryPotSmol : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lesser Recovery Potion");
            Tooltip.SetDefault("Recovers 15% of your max hp over 30 seconds");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;
        }

        public override void SetDefaults()
        {
            Item.height = 20;
            Item.width = 20;
            Item.rare = ItemRarityID.Green;
            Item.value = 1000;
            Item.buffType = Mod.Find<ModBuff>("Recovery").Type;
            Item.buffTime = 1800;
            Item.useStyle = ItemUseStyleID.EatFood;
            Item.useAnimation = 10;
            Item.useTime = 10;
            Item.consumable = true;
            Item.maxStack = 30;
            Item.UseSound = SoundID.Item3;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(2);
            recipe.AddIngredient(ItemID.LesserHealingPotion, 2);
            recipe.AddIngredient(ItemID.RegenerationPotion);
            recipe.AddTile(TileID.Bottles);
            recipe.Register();
        }
    }
}