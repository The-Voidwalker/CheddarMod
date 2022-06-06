using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheddarMod.Items
{
    public class GlassOmega : ModItem
    {
        private bool active = false;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Glass Omega");
            Tooltip.SetDefault("Possesses strange power.");
        }

        public override void SetDefaults()
        {
            item.width = 25;
            item.height = 25;
            item.rare = ItemRarityID.Purple;
            item.value = 100000;
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
            modPlayer.omega = !modPlayer.omega;
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
            active = player.GetModPlayer<CheddarModPlayer>().omega;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Glass, 10);
            recipe.AddRecipeGroup("Cheddar:GoldOres");
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}