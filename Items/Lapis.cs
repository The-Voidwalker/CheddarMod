using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheddarMod.Items
{
    public class Lapis : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lapis Philosophorum");
            Tooltip.SetDefault("\"Perfection achieved!\"\nIncreases armor penetration by 20\nProvides benefits of components\nBoots effectiveness of health potions and duration of other potions by 50%\nWhen the accessory is visible, nearby enemies have their defense reduced by 20 and are slowly turned to money\nWhen the accessory is not visible, defense is increased by 12, and damage may be exchanged for coins\nModerately improves item grab range");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 52;
            Item.height = 50;
            Item.value = 1000000;
            Item.rare = ItemRarityID.Purple;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetArmorPenetration(DamageClass.Generic) += 20;
            player.pStone = true;
            player.starCloakItem = Item;  // TODO: help
            player.longInvince = true;
            player.shinyStone = true;
            player.goldRing = true;
            //player.coins = true;
            player.discount = true;
            player.lifeRegen += 2;

            CheddarModPlayer mPlayer = player.GetModPlayer<CheddarModPlayer>();
            mPlayer.hBoost = 1.5f;
            mPlayer.bBoost = 1.5f;
            mPlayer.grabBoost += 62;

            if (hideVisual)
            {
                player.statDefense += 12;
                mPlayer.coinDefense = true;
            }
            else
            {
                mPlayer.midasCurse = true;
            }
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod, "HolySpork");
            recipe.AddIngredient(Mod, "PotentStone");
            recipe.AddIngredient(ItemID.ShinyStone);
            recipe.AddIngredient(ItemID.GreedyRing);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
        }
    }
}