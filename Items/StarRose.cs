using Terraria;
using Terraria.GameContent.Creative;
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
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 24;
            Item.value = 100000;
            Item.rare = ItemRarityID.Pink;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.manaCost -= 0.5f;
            player.GetDamage(DamageClass.Magic) -= 0.1f;
            player.GetCritChance(DamageClass.Magic) += 5;
        }
    }
}