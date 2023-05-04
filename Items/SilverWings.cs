using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheddarMod.Items
{
    class SilverWings : ModItem
    {
        private bool active = false;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Silver Wings");
            Tooltip.SetDefault("These delicate silver wings can grant immunity to fall damage, and give an extra jump without using an accessory.\n" +
                "Right click the charm in your inventory to gain its effect.");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 10;
            Item.height = 10;
            Item.rare = ItemRarityID.LightRed;
            Item.value = 777000;
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
            modPlayer.silverWings = !modPlayer.silverWings;
        }

        public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            if (active)
            {
                Texture2D texture = TextureAssets.Item[Item.type].Value;
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
            active = player.GetModPlayer<CheddarModPlayer>().silverWings;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddRecipeGroup("Cheddar:SilverBars", 7);
            recipe.AddIngredient(ItemID.Cloud, 7);
            recipe.AddIngredient(ItemID.Feather, 7);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
        }
    }
}
