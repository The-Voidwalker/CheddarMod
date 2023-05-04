using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheddarMod.Items
{
    public class RecoveryPotLarg : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Greater Recovery Potion");
            Tooltip.SetDefault("Recovers 45% of your max hp over 30 seconds");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;
        }

        public override void SetDefaults()
        {
            Item.height = 20;
            Item.width = 20;
            Item.rare = ItemRarityID.Green;
            Item.value = 1000;
            Item.buffType = Mod.Find<ModBuff>("RecoveryFast").Type;
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
            Recipe recipe = CreateRecipe(4);
            recipe.AddIngredient(Mod, "RecoveryPotSmol", 4);
            recipe.AddIngredient(ItemID.FragmentSolar);
            recipe.AddIngredient(ItemID.FragmentNebula);
            recipe.AddIngredient(ItemID.FragmentVortex);
            recipe.AddIngredient(ItemID.FragmentStardust);
            recipe.AddTile(TileID.Bottles);
            recipe.Register();
        }
    }
}