using Terraria;
using Terraria.GameContent.Creative;
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
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 28;
            Item.value = 1000000;
            Item.rare = ItemRarityID.Purple;
            Item.accessory = true;
            Item.defense = 5;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.manaCost = 0f;
            //player.manaMagnet = true;
            player.GetDamage(DamageClass.Magic) += 0.3f;
            player.GetCritChance(DamageClass.Magic) += 30;
            player.kbGlove = true;
            player.GetAttackSpeed(DamageClass.Melee) += 0.3f;
            player.GetDamage(DamageClass.Melee) += 0.3f;
            player.GetCritChance(DamageClass.Generic) += 30;
            player.magmaStone = true;
            player.GetCritChance(DamageClass.Ranged) += 30;
            player.GetDamage(DamageClass.Ranged) += 0.3f;
            player.magicQuiver = true;
            player.arrowDamage += 0.3f;
            player.accMerman = true;
            player.hideMerman = true;
            player.wolfAcc = true;
            player.hideWolf = true;
            player.lifeRegen += 5;
            player.pickSpeed -= 0.3f;
            player.GetDamage(DamageClass.Summon) += 0.3f;
            player.GetKnockback(DamageClass.Summon).Base += 3;
            player.GetDamage(DamageClass.Throwing) += 0.3f;
            player.GetCritChance(DamageClass.Throwing) += 30;
            player.maxMinions += 5;

            CheddarModPlayer modPlayer = player.GetModPlayer<CheddarModPlayer>();
            modPlayer.stuff = true;
            modPlayer.trueHero = true;
            if (!hideVisual)
            {
                modPlayer.scope = true;
            }
            modPlayer.healBeforeDeath = true;
            //modPlayer.flyte = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod, "TomeofAmmo");
            recipe.AddIngredient(Mod, "HeroEmblem");
            recipe.AddIngredient(Mod, "ScrollofThrowing");
            recipe.AddIngredient(Mod, "FocusCrystal");
            recipe.AddIngredient(Mod, "ArcaneTablet");
            recipe.AddIngredient(Mod, "GoldenSigil");
            recipe.AddIngredient(Mod, "CosmicSeal");
            recipe.AddIngredient(ItemID.CelestialShell);
            recipe.AddIngredient(ItemID.LunarBar, 5);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
        }
    }
}