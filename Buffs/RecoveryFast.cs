using Terraria;
using Terraria.ModLoader;

namespace CheddarMod.Buffs
{
	public class RecoveryFast : ModBuff
	{
		public int counter = 0;

		public override void SetDefaults()
		{
			DisplayName.SetDefault("Recovery");
			Description.SetDefault("Recovering 3% max hp every 2 seconds");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.ClearBuff(mod.BuffType("Recovery"));
			counter++;
			if( counter >= 120 )
			{
				counter = 0;
				int recover = (int)(player.statLifeMax2 * 0.031f);
				player.statLife += recover;
				if( player.statLife > player.statLifeMax2 )
				{
					player.statLife = player.statLifeMax2;
				}
				player.HealEffect(recover, true);
			}
		}
	}
}