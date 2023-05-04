using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheddarMod.Items
{
    public class PotentStone : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stone of Potency");
            Tooltip.SetDefault("Increases health regeneration by 1\nBoosts healing potion effectiveness by 20%\nIncreases potion duration by 35%");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.height = 20;
            Item.width = 20;
            Item.rare = ItemRarityID.Pink;
            Item.value = 30000;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            CheddarModPlayer mPlayer = player.GetModPlayer<CheddarModPlayer>();
            mPlayer.hBoost = 1.3f;
            mPlayer.bBoost = 1.35f;
            player.lifeRegen += 1;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod, "Regenerator");
            recipe.AddIngredient(ItemID.SoulofLight, 2);
            recipe.AddRecipeGroup("Cheddar:CobaltOres", 3);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}