using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheddarMod.Items
{
    public class TomeofAmmo : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tome of Ammo");
            Tooltip.SetDefault("This tome contains instructions for conjuring ammunition from nothing\nIncreases ranged stats by 15%, and you preserve all ammo");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 25;
            Item.height = 25;
            Item.rare = ItemRarityID.Lime;
            Item.value = 20000;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Ranged) += 0.15f;
            player.GetCritChance(DamageClass.Ranged) += 15;

            CheddarModPlayer modPlayer = player.GetModPlayer<CheddarModPlayer>();
            modPlayer.tome = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod, "AmmomancerPouch");
            recipe.AddIngredient(ItemID.EndlessQuiver);
            recipe.AddIngredient(ItemID.EndlessMusketPouch);
            recipe.AddTile(TileID.CrystalBall);
            recipe.Register();
        }
    }
}