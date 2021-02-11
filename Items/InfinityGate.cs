using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheddarMod.Items
{
    public class InfinityGate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Infinity Gate");
            Tooltip.SetDefault("Increases all attack and crit chance by 30%\nProvides all effects of components\nDisables item consumption\n\"The path to infinite power\"");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 28;
            item.value = 1000000;
            item.rare = 12;
            item.accessory = true;
            item.defense = 5;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.manaCost = 0f;
            //player.manaMagnet = true;
            player.magicDamage += 0.3f;
            player.magicCrit += 30;
            player.kbGlove = true;
            player.meleeSpeed += 0.3f;
            player.meleeDamage += 0.3f;
            player.meleeCrit += 30;
            player.magmaStone = true;
            player.rangedCrit += 30;
            player.rangedDamage += 0.3f;
            player.magicQuiver = true;
            player.arrowDamage += 0.3f;
            player.accMerman = true;
            player.hideMerman = true;
            player.wolfAcc = true;
            player.hideWolf = true;
            player.lifeRegen += 5;
            player.pickSpeed -= 0.3f;
            player.minionDamage += 0.3f;
            player.minionKB += 3;
            player.thrownDamage += 0.3f;
            player.thrownCrit += 30;
            player.maxMinions += 5;

            CheddarModPlayer modPlayer = player.GetModPlayer<CheddarModPlayer>();
            modPlayer.stuff = true;
            modPlayer.trueHero = true;
            if (!hideVisual)
            {
                modPlayer.scope = true;
            }
            modPlayer.healBeforeDeath = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, "TomeofAmmo");
            recipe.AddIngredient(mod, "HeroEmblem");
            recipe.AddIngredient(mod, "ScrollofThrowing");
            recipe.AddIngredient(mod, "FocusCrystal");
            recipe.AddIngredient(mod, "ArcaneTablet");
            recipe.AddIngredient(mod, "GoldenSigil");
            recipe.AddIngredient(mod, "CosmicSeal");
            recipe.AddIngredient(ItemID.CelestialShell);
            recipe.AddIngredient(ItemID.LunarBar, 5);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}