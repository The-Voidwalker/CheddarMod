using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheddarMod.Items
{
    public class YeetForce : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Golden Arrow");
            Tooltip.SetDefault("Hold left click with this charm to fly towards your mouse.");
        }

        public override void SetDefaults()
        {
            item.width = 9;
            item.height = 25;
            item.value = 500000;
            item.rare = ItemRarityID.Yellow;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.channel = true;
            item.useTime = 1;
            item.useAnimation = 1;
            item.autoReuse = true;
            item.useTurn = true;
        }

        public override bool UseItem(Player player)
        {
            Vector2 mouse = Main.MouseWorld;
            Vector2 direction = mouse - player.Center;
            if (direction.Length() < 40)
            {
                direction = Vector2.Zero;
                player.gravity = 0;
            }
            else
            {
                direction.Normalize();
                direction *= 30;
            }
            player.velocity = direction;
            return false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("Cheddar:GoldBars", 7);
            recipe.AddIngredient(ItemID.SoulofLight, 7);
            recipe.AddIngredient(ItemID.SoulofFlight, 7);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}