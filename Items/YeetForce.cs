using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.GameContent.Creative;
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
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 9;
            Item.height = 25;
            Item.value = 500000;
            Item.rare = ItemRarityID.Yellow;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.channel = true;
            Item.useTime = 1;
            Item.useAnimation = 1;
            Item.autoReuse = true;
            Item.useTurn = true;
        }

        public override Nullable<bool> UseItem(Player player)/* tModPorter Suggestion: Return null instead of false */
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
            Recipe recipe = CreateRecipe();
            recipe.AddRecipeGroup("Cheddar:GoldBars", 7);
            recipe.AddIngredient(ItemID.SoulofLight, 7);
            recipe.AddIngredient(ItemID.SoulofFlight, 7);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
        }
    }
}