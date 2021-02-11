using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheddarMod.Items
{
    public class WornEmblem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Worn Emblem");
            Tooltip.SetDefault("This worn emblem of an ancient hero still holds a fragment of it's power.\nAdds autoswing to all melee weapons at the cost of slower swings.");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.rare = ItemRarityID.LightRed;
            item.value = 40000;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            CheddarModPlayer modPlayer = player.GetModPlayer<CheddarModPlayer>();
            modPlayer.hero = true;

            player.meleeSpeed -= 0.15f;
            player.meleeDamage += 0.05f;
            player.meleeCrit += 5;
        }
    }
}