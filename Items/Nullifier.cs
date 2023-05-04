using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheddarMod.Items
{
    public class Nullifier : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nullifier");
            Tooltip.SetDefault("Provides immunity to knockback and most debuffs\nNullifies a portion of incoming damage\n20% of critical strikes against the player are resisted");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 30;
            Item.value = 500000;
            Item.rare = ItemRarityID.Cyan;
            Item.defense = 20;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.noKnockback = true;
            player.fireWalk = true;
            player.buffImmune[BuffID.Bleeding] = true;
            player.buffImmune[BuffID.Poisoned] = true;
            player.buffImmune[BuffID.OnFire] = true;
            player.buffImmune[BuffID.Venom] = true;
            player.buffImmune[BuffID.Darkness] = true;
            player.buffImmune[BuffID.Blackout] = true;
            player.buffImmune[BuffID.Silenced] = true;
            player.buffImmune[BuffID.Cursed] = true;
            player.buffImmune[BuffID.Confused] = true;
            player.buffImmune[BuffID.Slow] = true;
            player.buffImmune[BuffID.OgreSpit] = true;
            player.buffImmune[BuffID.Weak] = true;
            player.buffImmune[BuffID.BrokenArmor] = true;
            player.buffImmune[BuffID.WitheredArmor] = true;
            player.buffImmune[BuffID.WitheredWeapon] = true;
            player.buffImmune[BuffID.CursedInferno] = true;
            player.buffImmune[BuffID.Ichor] = true;
            player.buffImmune[BuffID.Chilled] = true;
            player.buffImmune[BuffID.Frozen] = true;
            player.buffImmune[BuffID.Webbed] = true;
            player.buffImmune[BuffID.Stoned] = true;
            player.buffImmune[BuffID.VortexDebuff] = true;
            player.buffImmune[BuffID.Electrified] = true;
            player.buffImmune[BuffID.WindPushed] = true;
            player.buffImmune[BuffID.Frostburn] = true;
            player.buffImmune[BuffID.ShadowFlame] = true;
            player.endurance += 0.05f;
            player.GetModPlayer<CheddarModPlayer>().resistance += 0.2f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod, "RedOctagon");
            recipe.AddIngredient(ItemID.LunarBar, 5);
            recipe.AddIngredient(ItemID.MartianConduitPlating, 10);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
        }
    }
}