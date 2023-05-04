using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheddarMod.Items
{
    public class CarvedBone : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Carved Bone");
            Tooltip.SetDefault("This bone is carven with mystic runes.\nIncreases maximum minions by 3, but reduces minion damage by 20%");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 25;
            Item.height = 25;
            Item.rare = ItemRarityID.LightRed;
            Item.value = 30000;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.maxMinions += 3;
            player.GetDamage(DamageClass.Summon) -= 0.2f;
        }
    }
}