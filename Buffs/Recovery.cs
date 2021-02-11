using Terraria;
using Terraria.ModLoader;

namespace CheddarMod.Buffs
{
    public class Recovery : ModBuff
    {
        public int counter = 0;

        public override void SetDefaults()
        {
            DisplayName.SetDefault("Recovery");
            Description.SetDefault("Recovering 1% max hp every 2 seconds");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            counter++;
            if (counter >= 120)
            {
                counter = 0;
                int recover = (int)(player.statLifeMax2 * 0.011f);
                player.statLife += recover;
                player.HealEffect(recover, true);
            }
        }
    }
}