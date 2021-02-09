using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheddarMod
{
	public class CheddarMod : Mod
	{
		public CheddarMod() {}

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

	public class CheddarWorld : ModWorld
	{
		// Don't need/want to save this
		public static bool timeWheel = false;

		public override void Initialize()
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

		public override void PreUpdate()
		{
			// TODO This effect pauses briefly at 4:30am in multiplayer, why?
			if ( Main.sundialCooldown == 8 )
				return; // Regular sundial effect in use, don't do anything

			if ( timeWheel )
			{
				Main.dayRate = 60;
				Main.fastForwardTime = true;
			}
			else
			{
				Main.fastForwardTime = false; // dayRate should be reset automatically by this
			}
		}
	}

	public class CheddarItem : GlobalItem
	{
		public override bool InstancePerEntity
		{
			get { return true; }
		}

		bool RealAutoReuseValue = false;
		bool FakeAutoReuse = false;
		int oldDuration = 0;

		public override bool CloneNewInstances => true;

		public override bool ConsumeAmmo(Item item, Player player)
		{
			CheddarModPlayer modPlayer = player.GetModPlayer<CheddarModPlayer>();
			if( modPlayer.tome || modPlayer.stuff || (modPlayer.ammomancer && Main.rand.Next(2) == 0) )
			{
				return false;
			}
			return true;
		}

		public override bool ConsumeItem(Item item, Player player)
		{
			CheddarModPlayer modPlayer = player.GetModPlayer<CheddarModPlayer>();
			if( modPlayer.stuff )
			{
				return false;
			}
			else if ( item.thrown && (modPlayer.scroll || (modPlayer.pocket && Main.rand.Next(2) == 0) ) )
			{
				return false;
			}
			else if ( (item.buffType > 0 || item.potion || item.healLife > 0 || item.healMana > 0) && modPlayer.potionSaver )
			{
				return false;
			}
			return true;
		}

		public override bool CanUseItem(Item item, Player player)
		{
			CheddarModPlayer modPlayer = player.GetModPlayer<CheddarModPlayer>();
			if((modPlayer.trueHero && item.damage > 0) || (item.melee && modPlayer.hero))
			{
				if(!FakeAutoReuse)
				{
					RealAutoReuseValue = item.autoReuse;
					FakeAutoReuse = true;
				}
				item.autoReuse = true;
			}
			else
			{
				if(FakeAutoReuse)
				{
					item.autoReuse = RealAutoReuseValue;
					FakeAutoReuse = false;
				}
			}
			return base.CanUseItem(item, player);
		}

		public override bool UseItem(Item item, Player player)
		{
			if(item.buffTime > 0)
			{
				oldDuration = oldDuration > 0 ? oldDuration : item.buffTime;
				item.buffTime = (int)(oldDuration * player.GetModPlayer<CheddarModPlayer>().bBoost);
			}
			return false;
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
			if((projectile.aiStyle == 19 || projectile.aiStyle == 699) &&
				Main.player[projectile.owner].HeldItem.melee && (modPlayer.hero || modPlayer.trueHero) &&
				projectile.timeLeft > Main.player[projectile.owner].itemAnimation)
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
			if( this.midasCurse )
			{
				if(npc.lifeRegen > 0)
				{
					npc.lifeRegen = 0;
				}
				npc.lifeRegen -= 40;
				if( damage < 5 )
				{
					damage = 5;
				}

				this.coinCount++;
				if( coinCount > 120 )
				{
					float r = Main.rand.NextFloat();
					int coin;
					int num;
					if( r < 0.6f )
					{
						coin = ItemID.CopperCoin;
						num = Main.rand.Next(20, 100);
					}
					else if ( r < 0.9f )
					{
						coin = ItemID.SilverCoin;
						num = Main.rand.Next(10, 60);
					}
					else
					{
						coin = ItemID.GoldCoin;
						num = Main.rand.Next(3, 13);
					}

					Item.NewItem(npc.getRect(), coin, num);
					this.coinCount = 0;
				}
			}
			else
			{
				this.coinCount = 0;
			}
		}

		public override void NPCLoot(NPC npc)
		{
			if(npc.type == NPCID.KingSlime && Main.rand.Next(5) == 0)
			{
				Item.NewItem(npc.getRect(), mod.ItemType("RadiantOoze"));
			}
			if((((npc.type == NPCID.EaterofWorldsHead || npc.type == NPCID.EaterofWorldsBody || npc.type == NPCID.EaterofWorldsTail) && npc.boss) ||
				npc.type == NPCID.BrainofCthulhu) && Main.rand.NextFloat() < 0.15f)
			{
				Item.NewItem(npc.getRect(), mod.ItemType("WornEmblem"));
			}
			if(npc.type == NPCID.EyeofCthulhu && Main.rand.Next(5) == 0)
			{
				Item.NewItem(npc.getRect(), mod.ItemType("EngravedLens"));
			}
			if(npc.type == NPCID.QueenBee && Main.rand.NextFloat() < 0.15f)
			{
				Item.NewItem(npc.getRect(), mod.ItemType("StarRose"));
			}
			if(npc.type == NPCID.SkeletronHead && Main.rand.NextFloat() < 0.15f)
			{
				Item.NewItem(npc.getRect(), mod.ItemType("CarvedBone"));
			}
			if((npc.type == NPCID.CultistBoss || npc.type == NPCID.LunarTowerSolar ||
				npc.type == NPCID.LunarTowerStardust || npc.type == NPCID.LunarTowerNebula ||
				npc.type == NPCID.LunarTowerVortex) && Main.rand.Next(npc.type == NPCID.CultistBoss ? 10 : 20) == 0)
			{
				Item.NewItem(npc.getRect(), mod.ItemType("CosmicSeal"));
			}
			// The set of enemies from StardustWormHead to VortexSoldier is a continuous set of Lunar Events enemies
			// BUG: One of the pillars is in this set, but whatever
			if(Main.rand.Next(500) == 0 &&
				(npc.type >= NPCID.StardustWormHead && npc.type <= NPCID.VortexSoldier))
			{
				Item.NewItem(npc.getRect(), mod.ItemType("CosmicSeal"));
			}
		}
	}
}