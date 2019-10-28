using System;
using System.IO;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace CheddarMod
{
	public class CheddarMod : Mod
	{
		public CheddarMod()
		{
			// Defaults are exactly what they should be
		}
	}

    public class CheddarModPlayer : ModPlayer
    {
        public bool yeet = false;
		public bool pocket = false;
		public bool ammomancer = false;
		public bool stuff = false;
		public bool hero = false;
		public bool trueHero = false;
		public bool flyte = false;

        public override void ResetEffects()
        {
            yeet = false;
			pocket = false;
			ammomancer = false;
			stuff = false;
			hero = false;
			trueHero = false;
			flyte = false;
        }

        public override void PostUpdate()
        {
            if( this.yeet && !player.jumpAgainCloud )
            {
                player.jumpAgainCloud = true;
            }
			if( this.flyte && player.wingTime < 10f )
			{
				player.wingTime += 200f;
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

		public override bool CloneNewInstances => true;

		public override bool ConsumeAmmo(Item item, Player player)
		{
			CheddarModPlayer modPlayer = player.GetModPlayer<CheddarModPlayer>();
			if( modPlayer.ammomancer || modPlayer.stuff )
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
			else if ( item.thrown && modPlayer.pocket )
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
}