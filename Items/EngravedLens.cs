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
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.rare = ItemRarityID.Orange;
            item.value = 7000;
        }
    }
}