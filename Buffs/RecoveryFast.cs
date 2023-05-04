using Terraria;
using Terraria.ModLoader;

namespace CheddarMod.Buffs
{
    public class RecoveryFast : ModBuff
    {
        public int counter = 0;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Recovery");
            Description.SetDefault("Recovering 3% max hp every 2 seconds");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.ClearBuff(Mod.Find<ModBuff>("Recovery").Type);
            counter++;
            if (counter >= 120)
            {
                counter = 0;
                int recover = (int)(player.statLifeMax2 * 0.031f);
                player.statLife += recover;
                player.HealEffect(recover, true);
            }
        }
    }
}