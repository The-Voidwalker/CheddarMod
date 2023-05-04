using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheddarMod.Items
{
    public class EternalBacon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eternal Bacon");
            Tooltip.SetDefault("Praise the ETERNAL BACON!\nALL PRAISE!");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.UseSound = SoundID.Item2;
            Item.useStyle = ItemUseStyleID.EatFood;
            Item.useTurn = true;
            Item.useAnimation = 17;
            Item.useTime = 17;
            // item.maxStack = 1;
            Item.consumable = false;
            Item.width = 10;
            Item.height = 10;
            Item.buffType = 26;
            Item.buffTime = 216000;
            Item.rare = ItemRarityID.Green;
            Item.value = 10000;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Bacon, 30);
            recipe.Register();
        }
    }
}