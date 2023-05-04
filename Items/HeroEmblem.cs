using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheddarMod.Items
{
    public class HeroEmblem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hero's Emblem");
            Tooltip.SetDefault("Its power has been restored.\nIncreases Melee damage and crit by 15% and Melee speed by 10%.\nMelee weapons auto swing");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 26;
            Item.value = 50000;
            Item.rare = ItemRarityID.Pink;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Melee) += 0.15f;
            player.GetCritChance(DamageClass.Generic) += 15;
            player.GetAttackSpeed(DamageClass.Melee) += 0.1f;

            CheddarModPlayer modPlayer = player.GetModPlayer<CheddarModPlayer>();
            modPlayer.hero = true;
        }

        public override void AddRecipes()
        {
            Recipe recipeGold = CreateRecipe();
            recipeGold.AddIngredient(Mod, "WornEmblem");
            recipeGold.AddRecipeGroup("Cheddar:GoldBars");
            recipeGold.AddTile(TileID.MythrilAnvil);
            recipeGold.Register();
        }
    }
}