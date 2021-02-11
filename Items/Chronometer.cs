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
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 30;
            item.rare = ItemRarityID.Cyan;
            item.value = 5000000;
        }

        public override bool Autoload(ref string name)
        {
            return false;
        }
    }
}
