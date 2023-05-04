using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheddarMod.Items
{
    public class EngravedLens : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Engraved Lens");
            Tooltip.SetDefault("A lens with mystical properties.\nCan be used for something.");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.rare = ItemRarityID.Orange;
            Item.value = 7000;
        }
    }
}