using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using static Terraria.ModLoader.ModContent;

namespace CheddarMod
{
    public class CheddarModPlayer : ModPlayer
    {
        public bool yeet = false;
        public bool pocket = false;
        public bool ammomancer = false;
        public bool stuff = false;
        public bool hero = false;
        public bool trueHero = false;
        public bool flyte = false;
        public bool scope = false;
        public bool potionSaver = false;
        public bool healBeforeDeath = false;
        private bool sickFromSeal = false;
        public bool tome = false;
        public bool scroll = false;
        public float hBoost = 1f;
        public float bBoost = 1f;
        public float bBoost2 = 1f;
        public bool midasCurse = false;
        public bool coinDecay = false;
        private int coinCount = 0;
        public bool coinDefense = false;
        public int grabBoost = 0;
        public float resistance = 0f;
        public bool silverWings = false;
        public bool omega = false;

        public override void SaveData(TagCompound tag)
        {
            tag.Set("wings", silverWings, true);
            tag.Set("flyte", flyte, true);
            tag.Set("omega", omega, true);
        }

        public override void LoadData(TagCompound tag)
        {
            silverWings = tag.GetBool("wings");
            flyte = tag.GetBool("flyte");
            omega = tag.GetBool("omega");
        }

        public override void ResetEffects()
        {
            yeet = false;
            pocket = false;
            ammomancer = false;
            stuff = false;
            hero = false;
            trueHero = false;
            scope = false;
            potionSaver = false;
            healBeforeDeath = false;
            tome = false;
            scroll = false;
            hBoost = 1f;
            if (bBoost != bBoost2)
            {
                bBoost2 = bBoost; // Delay updates to bBoost
            }
            bBoost = 1f;
            midasCurse = false;
            coinDecay = false;
            coinDefense = false;
            grabBoost = 0;
            resistance = 0f;
        }

        public override void GetHealLife(Item item, bool quickHeal, ref int healValue)
        {
            healValue = (int)(healValue * hBoost);
        }

        public override void PreUpdate()
        {
            if (flyte)
            {
                Player.maxFallSpeed += 5f;
                Player.noFallDmg = true;
            }
            else if (yeet)
            {
                Player.maxFallSpeed += 3f;
            }
            if (silverWings)
            {
                Player.noFallDmg = true;
            }

            if (Player.channel && Player.inventory[Player.selectedItem].netID == Mod.Find<ModItem>("YeetForce").Type ||
                Player.inventory[Player.selectedItem].netID == Mod.Find<ModItem>("Flyte").Type)
            {
                Player.maxFallSpeed = 1000;
                if ((Main.MouseWorld - Player.Center).Length() < 40)
                {
                    Player.gravity = 0;
                }
            }
        }

        public override void PostUpdate()
        {
            if (flyte)
            {
                if (Player.wingTime < 10f)
                {
                    Player.wingTime += 200f;
                }
            }

            if (yeet && !Player.canJumpAgain_Cloud)
            {
                Player.canJumpAgain_Cloud = true;
            }

            if ((Player.inventory[Player.selectedItem].useAmmo == AmmoID.Bullet
                 || Player.inventory[Player.selectedItem].useAmmo == AmmoID.CandyCorn
                 || Player.inventory[Player.selectedItem].useAmmo == AmmoID.Stake
                 || Player.inventory[Player.selectedItem].useAmmo == AmmoID.Gel)
                && scope && Player.altFunctionUse == 0)
            {
                Player.scope = true;
            }
            if (sickFromSeal && Player.potionDelay == 0)
            {
                sickFromSeal = false;
            }

            if (midasCurse && Player.whoAmI == Main.myPlayer)
            {
                for (int i = 0; i < 200; i++)
                {
                    NPC npc = Main.npc[i];
                    if (npc.active
                        && !npc.friendly
                        && npc.damage > 0
                        && !npc.dontTakeDamage
                        && !npc.buffImmune[Mod.Find<ModBuff>("MidasCurse").Type]
                        && Vector2.Distance(Player.Center, npc.Center) <= 400f)
                    {
                        npc.AddBuff(Mod.Find<ModBuff>("MidasCurse").Type, 120);
                    }
                }
            }
        }

        public override void PostUpdateEquips()
        {
            if (silverWings)
            {
                Player.hasJumpOption_Unicorn = true;
            }
            if (omega && GetInstance<CheddarModConfig>().GlassOmegaMana)
            {
                Player.manaCost = 0;
            }
        }

        public override void UpdateBadLifeRegen()
        {
            if (coinDecay)
            {
                if (Player.lifeRegen > 0)
                {
                    Player.lifeRegen = 0;
                }
                Player.lifeRegenTime = 0;
                Player.lifeRegen -= 20;

                coinCount++;
                if (coinCount > 120)
                {
                    float r = Main.rand.NextFloat();
                    int coin;
                    int num;
                    if (r < 0.6f)
                    {
                        coin = ItemID.CopperCoin;
                        num = Main.rand.Next(20, 100);
                    }
                    else if (r < 0.9f)
                    {
                        coin = ItemID.SilverCoin;
                        num = Main.rand.Next(10, 60);
                    }
                    else
                    {
                        coin = ItemID.GoldCoin;
                        num = Main.rand.Next(3, 13);
                    }

                    Player.QuickSpawnItem(Player.GetSource_Loot(), coin, num);
                    coinCount = 0;
                }
            }
            else
            {
                coinCount = 0;
            }
        }

        public override bool PreKill(
            double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore,
            ref PlayerDeathReason damageSource)
        {
            if (healBeforeDeath && Main.rand.NextBool(10))
            {
                if (!sickFromSeal)
                {
                    Player.ClearBuff(BuffID.PotionSickness);
                    Player.potionDelay = 0;
                }
                Player.QuickHeal();
                if (Player.statLife <= 0)
                {
                    return true;
                }
                sickFromSeal = true;
                return false;
            }
            return true;
        }

        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource, ref int cooldownCounter)
        {
            damage = (int)(damage * (1.001f + resistance));

            if (crit && Main.rand.NextFloat() < resistance)
            {
                crit = false;
            }

            if (damage > 1 && coinDefense && Main.rand.NextBool(5))
            {
                float r = Main.rand.NextFloat();
                int num = Main.rand.Next(11);
                float mult = (float)num / 100f;
                int coin;
                int coins = num + 1;

                if (r < 0.5f)
                {
                    coin = ItemID.CopperCoin;
                    mult += 0.1f;
                    coins *= 10;
                }
                else if (r < 0.85f)
                {
                    coin = ItemID.SilverCoin;
                    mult += 0.25f;
                    coins *= Main.rand.Next(2, 9);
                }
                else if (r < 0.99f)
                {
                    coin = ItemID.GoldCoin;
                    mult += 0.5f;
                }
                else
                {
                    coin = ItemID.PlatinumCoin;
                    mult = 0.99f;
                    coins = 1;
                }

                int reduction = (int)(damage * mult);
                damage -= reduction;
                Player.QuickSpawnItem(Player.GetSource_Loot(), coin, coins);
            }
            return true;
        }
    }
}