using System.ComponentModel;
using System.IO;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace CheddarMod
{
    public class CheddarMod : Mod
    {
        public CheddarMod() { }

        public static CheddarMod Instance;

        public override void Load()
        {
            Instance = this;
        }

        public override void Unload()
        {
            Instance = null;
        }

        public override void HandlePacket(BinaryReader reader, int whoAmI)
        {
            NetHelper.HandlePacket(reader, whoAmI);
        }
    }

    public class CheddarWorld : ModSystem
    {
        // Don't need/want to save this
        public static bool timeWheel = false;

        public override void OnWorldLoad()/* tModPorter Suggestion: Also override OnWorldUnload, and mirror your worldgen-sensitive data initialization in PreWorldGen */
        {
            timeWheel = false;
        }

        public override void NetSend(BinaryWriter writer)
        {
            writer.Write(timeWheel);
        }

        public override void NetReceive(BinaryReader reader)
        {
            timeWheel = reader.ReadBoolean();
        }

        public override void PreUpdateWorld()
        {
            // TODO This effect pauses briefly at 4:30am in multiplayer, why?
            if (Main.sundialCooldown == 8)
            {
                return; // Regular sundial effect in use, don't do anything
            }

            if (timeWheel)
            {
                Main.dayRate = 60;
                Main.fastForwardTime = true;
            }
            else
            {
                Main.fastForwardTime = false; // dayRate should be reset automatically by this
            }
        }

        public override void AddRecipeGroups()
        {
            RecipeGroup group = new RecipeGroup(() => "Silver or Tungsten bar", new int[]
            {
                ItemID.SilverBar,
                ItemID.TungstenBar
            });
            RecipeGroup.RegisterGroup("Cheddar:SilverBars", group);

            RecipeGroup gold = new RecipeGroup(() => "Gold or Platinum bar", new int[]
            {
                ItemID.GoldBar,
                ItemID.PlatinumBar
            });
            RecipeGroup.RegisterGroup("Cheddar:GoldBars", gold);

            RecipeGroup goldOre = new RecipeGroup(() => "Gold or Platinum ore", new int[]
            {
                ItemID.GoldOre,
                ItemID.PlatinumOre
            });
            RecipeGroup.RegisterGroup("Cheddar:GoldOres", goldOre);

            RecipeGroup earlyHMOre = new RecipeGroup(() => "Cobalt or Palladium ore", new int[]
            {
                ItemID.CobaltOre,
                ItemID.PalladiumOre
            });
            RecipeGroup.RegisterGroup("Cheddar:CobaltOres", earlyHMOre);
        }
    }

    public class CheddarItem : GlobalItem
    {
        bool RealAutoReuseValue = false;
        bool FakeAutoReuse = false;
        int oldDuration = 0;

        public override bool InstancePerEntity => true;
        protected override bool CloneNewInstances => true;

        public override bool CanConsumeAmmo(Item weapon, Item ammo, Player player)
        {
            CheddarModPlayer modPlayer = player.GetModPlayer<CheddarModPlayer>();
            return !modPlayer.tome && !modPlayer.stuff && !modPlayer.omega && (!modPlayer.ammomancer || !Main.rand.NextBool(2));
        }

        public override bool ConsumeItem(Item item, Player player)
        {
            CheddarModPlayer modPlayer = player.GetModPlayer<CheddarModPlayer>();
            if (modPlayer.stuff || modPlayer.omega)
            {
                return false;
            }
            else if (item.CountsAsClass(DamageClass.Throwing) && (modPlayer.scroll || (modPlayer.pocket && Main.rand.NextBool(2))))
            {
                return false;
            }
            else if ((item.buffType > 0 || item.potion || item.healLife > 0 || item.healMana > 0) && modPlayer.potionSaver)
            {
                return false;
            }
            return true;
        }

        public override bool CanUseItem(Item item, Player player)
        {
            CheddarModPlayer modPlayer = player.GetModPlayer<CheddarModPlayer>();
            if ((modPlayer.trueHero && item.damage > 0) || (item.CountsAsClass(DamageClass.Melee) && modPlayer.hero))
            {
                if (!FakeAutoReuse)
                {
                    RealAutoReuseValue = item.autoReuse;
                    FakeAutoReuse = true;
                }
                item.autoReuse = true;
            }
            else
            {
                if (FakeAutoReuse)
                {
                    item.autoReuse = RealAutoReuseValue;
                    FakeAutoReuse = false;
                }
            }
            return base.CanUseItem(item, player);
        }

        public override void UpdateInventory(Item item, Player player)
        {
            if (item.buffTime > 0)
            {
                oldDuration = oldDuration > 0 ? oldDuration : item.buffTime;
                // This method runs after ResetDefaults, but before UpdateAccessories
                // bBoost is therefore always 1, so bBoost2 updates one tick after actual changes to bBoost
                item.buffTime = (int)(oldDuration * player.GetModPlayer<CheddarModPlayer>().bBoost2);
            }
        }

        public override void GrabRange(Item item, Player player, ref int grabRange)
        {
            grabRange += player.GetModPlayer<CheddarModPlayer>().grabBoost;
        }
    }

    public class CheddarProjectile : GlobalProjectile
    {
        public override void AI(Projectile projectile)
        {
            CheddarModPlayer modPlayer = Main.player[projectile.owner].GetModPlayer<CheddarModPlayer>();
            if ((projectile.aiStyle == 19 || projectile.aiStyle == 699)
                && Main.player[projectile.owner].HeldItem.CountsAsClass(DamageClass.Melee)
                && (modPlayer.hero || modPlayer.trueHero)
                && projectile.timeLeft > Main.player[projectile.owner].itemAnimation)
            {
                projectile.timeLeft = Main.player[projectile.owner].itemAnimation;
                projectile.netUpdate = true;
            }
        }
    }

    public class CheddarGlobalNPC : GlobalNPC
    {
        private int coinCount = 0;
        public bool midasCurse = false;

        public override bool InstancePerEntity => true;

        public override void ResetEffects(NPC npc)
        {
            midasCurse = false;
        }

        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (midasCurse)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 40;
                if (damage < 5)
                {
                    damage = 5;
                }

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

                    Item.NewItem(npc.GetSource_DropAsItem(), npc.getRect(), coin, num);
                    coinCount = 0;
                }
            }
            else
            {
                coinCount = 0;
            }
        }

        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            switch (npc.type)
            {
                case NPCID.KingSlime:
                    npcLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("RadiantOoze").Type, 5));
                    break;
                case NPCID.EaterofWorldsBody:
                case NPCID.EaterofWorldsHead:
                case NPCID.EaterofWorldsTail:
                case NPCID.BrainofCthulhu:
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.LegacyHack_IsABoss(), Mod.Find<ModItem>("WornEmblem").Type, 20, 1, 1, 3));
                    break;
                case NPCID.EyeofCthulhu:
                    npcLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("EngravedLens").Type, 5));
                    break;
                case NPCID.QueenBee:
                    npcLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("StarRose").Type, 6));
                    break;
                case NPCID.SkeletronHead:
                    npcLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("CarvedBone").Type, 6));
                    break;
                case NPCID.CultistBoss:
                    npcLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("CosmicSeal").Type, 10));
                    break;
                case NPCID.LunarTowerNebula:
                case NPCID.LunarTowerSolar:
                case NPCID.LunarTowerStardust:
                case NPCID.LunarTowerVortex:
                    npcLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("CosmicSeal").Type, 20));
                    break;
            }
            // The set of enemies from StardustWormHead to VortexSoldier is a continuous set of Lunar Events enemies
            if (npc.type >= NPCID.StardustWormHead && npc.type <= NPCID.VortexSoldier && npc.type != NPCID.LunarTowerVortex)
            {
                npcLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("CosmicSeal").Type, 500));
            }
        }
    }

    public class CheddarModConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Label("Glass Omega removes mana consumption")]
        [Tooltip("Toggle whether or not the Glass Omega item's effect will remove mana consumption.")]
        [DefaultValue(false)]
        public bool GlassOmegaMana { get; set; }
    }
}