using System;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheddarMod.Items
{
    public class WheelOfTime : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wheel of Time");
            Tooltip.SetDefault("Holds power over time itself.\nLeft click to toggle faster time flow.\nRight click disables this effect.");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.rare = ItemRarityID.Lime;
            Item.value = 200000;
            Item.width = 20;
            Item.height = 20;
            Item.useAnimation = 45;
            Item.useTime = 45;
            Item.useStyle = ItemUseStyleID.HoldUp;
        }

        public override bool IsLoadingEnabled(Mod mod)/* tModPorter Suggestion: If you return false for the purposes of manual loading, use the [Autoload(false)] attribute on your class instead */
        {
            return true;
        }

        public override Nullable<bool> UseItem(Player player)/* tModPorter Suggestion: Return null instead of false */
        {
            if (player.altFunctionUse == 2)
            {
                return true; // Alt use calls this function, but we don't actually want it to do anything
            }

            bool enable;
            if (CheddarWorld.timeWheel)
            {
                enable = false;
            }
            else
            {
                enable = true;
            }

            ToggleWheel(enable, player);

            return true;
        }

        public override bool AltFunctionUse(Player player)
        {
            ToggleWheel(false, player);
            return true;
        }

        private void ToggleWheel(bool enabled, Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                CheddarWorld.timeWheel = enabled;
                if (Main.netMode == NetmodeID.MultiplayerClient)
                {
                    NetHelper.SendWheelUpdate(enabled); // Force synchronize status
                }
            }
        }
    }
}
