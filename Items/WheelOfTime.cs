using System;
using System.IO;
using Terraria;
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
		}

		public override void SetDefaults()
		{
			item.rare = ItemRarityID.Lime;
			item.value = 200000;
			item.width = 20;
			item.height = 20;
			item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = ItemUseStyleID.HoldingUp;
		}

		public override bool Autoload(ref string name)
        {
            return true;
        }

		public override bool UseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				return true; // Alt use calls this function, but we don't actually want it to do anything
			}

			bool enable;
			if ( CheddarWorld.timeWheel )
			{
				enable = false;
				// Main.NewText("Disabling");
				// Console.WriteLine("Disabled");
			}
			else
			{
				enable = true;
				// Main.NewText("Enabling");
				// Console.WriteLine("Enabled");
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
