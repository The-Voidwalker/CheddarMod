using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheddarMod.Items
{
    public class HolySpork : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Holy Spork");
            Tooltip.SetDefault("Increases armor penetration by 10.\nReduces potion cooldown.\nIncreases invincibility time when taking damage, and stars rain down while invincibility is active.\n\"All Hail The Spork!\"");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 38;
            Item.value = 600000;
            Item.rare = ItemRarityID.Lime;
            Item.lifeRegen = 2;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetArmorPenetration(DamageClass.Generic) += 10;
            player.pStone = true;
            player.starCloakItem = Item;  // TODO: help
            player.longInvince = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.StarVeil);
            recipe.AddIngredient(ItemID.CharmofMyths);
            recipe.AddIngredient(ItemID.SharkToothNecklace);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
        }
    }
}