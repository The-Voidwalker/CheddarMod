using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheddarMod.Items
{
    public class Chronometer : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chronometer");
            Tooltip.SetDefault("Right click to set a date and time, left click to take you there.");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 30;
            Item.rare = ItemRarityID.Cyan;
            Item.value = 5000000;
        }

        public override bool IsLoadingEnabled(Mod mod)/* tModPorter Suggestion: If you return false for the purposes of manual loading, use the [Autoload(false)] attribute on your class instead */
        {
            return false;
        }
    }
}
