using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheddarMod.Items
{
    public class RadiantOoze : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Radiant Ooze");
            Tooltip.SetDefault("A small mass of gel with mystical properties.\nPerhaps it can be used for something?");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.rare = ItemRarityID.Orange;
            Item.value = 6000;
        }
    }
}
