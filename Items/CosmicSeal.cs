using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheddarMod.Items
{
    public class CosmicSeal : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cosmic Seal");
            Tooltip.SetDefault("A little bit of eldrich power goes a long way.\nDisables potion consumption.\nOn death, the player has a 10% chance to quick-heal instead of die.\nThis effect ignores potion sickness that was not caused by itself.");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.value = 1200000;
            Item.rare = ItemRarityID.Purple;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            CheddarModPlayer modPlayer = player.GetModPlayer<CheddarModPlayer>();
            modPlayer.potionSaver = true;
            modPlayer.healBeforeDeath = true;
        }
    }
}
