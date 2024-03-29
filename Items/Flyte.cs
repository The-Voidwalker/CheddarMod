using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheddarMod.Items
{
    public class Flyte : ModItem
    {
        private bool active = false;
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flyte");
            Tooltip.SetDefault("Use this item to throw yourself toward your mouse.\n" +
                "This reconstructed charm can be activated to grant infinite flight.\n" +
                "Right click the charm in your inventory to gain its effect.");
        }

        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 38;
            item.value = 1000000;
            item.rare = 12;
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
                direction *= 50;
            }
            player.velocity = direction;
            return false;
        }

        public override bool ConsumeItem(Player player)
        {
            return false;
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
            CheddarModPlayer modPlayer = player.GetModPlayer<CheddarModPlayer>();
            modPlayer.flyte = !modPlayer.flyte;
        }

        public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            if (active)
            {
                Texture2D texture = Main.itemTexture[item.type];
                for (int i = 0; i < 8; i++)
                {
                    Vector2 offsetPositon = Vector2.UnitY.RotatedBy(MathHelper.PiOver2 * i) * 2;
                    spriteBatch.Draw(texture, position + offsetPositon, null, Main.DiscoColor, 0, origin, scale, SpriteEffects.None, 0f);
                }
            }
            return true;
        }

        public override void UpdateInventory(Player player)
        {
            active = player.GetModPlayer<CheddarModPlayer>().flyte;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, "YeetForce");
            recipe.AddIngredient(mod, "SilverWings");
            recipe.AddIngredient(ItemID.SoulofFright, 7);
            recipe.AddIngredient(ItemID.SoulofMight, 7);
            recipe.AddIngredient(ItemID.SoulofSight, 7);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}