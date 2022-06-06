using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheddarMod.Items
{
    public class StarRose : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rosy Star");
            Tooltip.SetDefault("This beautiful red crystal massively reduces mana costs in exchange for damage.");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 24;
            item.value = 100000;
            item.rare = ItemRarityID.Pink;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.manaCost -= 0.5f;
            player.magicDamage -= 0.1f;
            player.magicCrit += 5;
        }
    }
}