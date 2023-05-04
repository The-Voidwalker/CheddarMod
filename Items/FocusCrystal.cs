using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheddarMod.Items
{
    public class FocusCrystal : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Focus Crystal");
            Tooltip.SetDefault("Any spell can be cast, so long as the caster can maintain focus\nThis crystal ensures the caster always can focus\nIncreases magic stats by 15%\nDisables mana consumption");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 25;
            Item.height = 25;
            Item.rare = ItemRarityID.Lime;
            Item.value = 200000;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.manaCost = 0f;
            player.GetDamage(DamageClass.Magic) += 0.15f;
            player.GetCritChance(DamageClass.Magic) += 15;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod, "StarRose");
            recipe.AddIngredient(ItemID.CrystalShard, 15);
            recipe.AddTile(TileID.CrystalBall);
            recipe.Register();
        }
    }
}