using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheddarMod.Items
{
    public class ArcaneTablet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Arcane Tablet");
            Tooltip.SetDefault("Grants power over others, provided that you can summon them\nMax minions increased by 4\nMinion damage increased by 15%");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 25;
            Item.height = 25;
            Item.rare = ItemRarityID.Yellow;
            Item.value = 140000;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.maxMinions += 4;
            player.GetDamage(DamageClass.Summon) += 0.15f;
            player.GetKnockback(DamageClass.Summon).Base += 1;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod, "CarvedBone");
            recipe.AddIngredient(ItemID.SoulofNight, 9);
            recipe.AddTile(TileID.CrystalBall);
            recipe.Register();
        }
    }
}