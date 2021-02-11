using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheddarMod.Items
{
    public class Lapis : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lapis Philosophorum");
            Tooltip.SetDefault("Increases armor penetration by 20\nProvides benefits of components\nBoots effectiveness of health potions and duration of other potions by 50%\nWhen the accessory is visible, nearby enemies have their defense reduced by 20 and are slowly turned to money\nWhen the accessory is not visible, defense is increased by 12, and damage may be exchanged for coins\nModerately improves item grab range\n\"Perfection achieved!\"");
        }

        public override void SetDefaults()
        {
            item.width = 52;
            item.height = 50;
            item.value = 1000000;
            item.rare = 12;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.armorPenetration += 20;
            player.pStone = true;
            player.starCloak = true;
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
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, "HolySpork");
            recipe.AddIngredient(mod, "PotentStone");
            recipe.AddIngredient(ItemID.ShinyStone);
            recipe.AddIngredient(ItemID.GreedyRing);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}