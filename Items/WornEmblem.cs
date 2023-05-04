using Terraria;
using Terraria.GameContent.Creative;
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
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.rare = ItemRarityID.LightRed;
            Item.value = 40000;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            CheddarModPlayer modPlayer = player.GetModPlayer<CheddarModPlayer>();
            modPlayer.hero = true;

            player.GetAttackSpeed(DamageClass.Melee) -= 0.10f;
            player.GetDamage(DamageClass.Melee) += 0.05f;
            player.GetCritChance(DamageClass.Generic) += 5;
        }
    }
}