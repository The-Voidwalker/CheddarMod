using Terraria;
using Terraria.ModLoader;

namespace CheddarMod.Buffs
{
    public class MidasCurse : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Midas' Curse");
            Description.SetDefault("You are turning into coins!");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<CheddarModPlayer>().coinDecay = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.defense -= 20;
            npc.GetGlobalNPC<CheddarGlobalNPC>().midasCurse = true;
        }
    }
}