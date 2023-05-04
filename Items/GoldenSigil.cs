using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheddarMod.Items
{
    public class GoldenSigil : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Golden Sigil");
            Tooltip.SetDefault("The mark of a great warrior\nIncreases magic, ranged, and melee damage by 15%\nIncreases crit chance for the same by 10%\nProvides the benefits of its components");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 32;
            Item.value = 500000;
            Item.rare = ItemRarityID.Red;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.manaMagnet = true;
            player.GetDamage(DamageClass.Magic) += 0.15f;
            player.GetCritChance(DamageClass.Magic) += 10;
            player.kbGlove = true;
            player.GetAttackSpeed(DamageClass.Melee) += 0.1f;
            player.GetDamage(DamageClass.Melee) += 0.15f;
            player.GetCritChance(DamageClass.Generic) += 10;
            player.magmaStone = true;
            player.GetCritChance(DamageClass.Ranged) += 10;
            player.GetDamage(DamageClass.Ranged) += 0.15f;
            player.magicQuiver = true;
            player.arrowDamage += 0.15f;

            CheddarModPlayer modPlayer = player.GetModPlayer<CheddarModPlayer>();
            modPlayer.scope = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.CelestialEmblem);
            recipe.AddIngredient(ItemID.FireGauntlet);
            recipe.AddIngredient(ItemID.SniperScope);
            recipe.AddIngredient(ItemID.MagicQuiver);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}