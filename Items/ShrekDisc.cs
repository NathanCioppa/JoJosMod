using JoJosMod.Projectiles;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace JoJosMod.Items
{
    internal class ShrekDisc : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cinematic Masterpiece");
            Tooltip.SetDefault("Deals more damage the longer it stays in the air\n\"Do the roar.\"");
        }

        public static float throwVelocity = 17.5f;

        public override void SetDefaults()
        {
            Item.width = 100; Item.height = 100;
            Item.damage = 120;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.DamageType = DamageClass.Melee;
            Item.rare = ItemRarityID.Lime;           
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.noUseGraphic = true;
            Item.shootSpeed = throwVelocity;
            Item.shoot = ModContent.ProjectileType<ShrekDiscProjectile>();
            Item.consumable = false;
            Item.noMelee = true;
            Item.maxStack = 1;
            Item.stack = 1;
            Item.value = 90000;
            Item.knockBack = 6;
            Item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.ChlorophyteBar, 5);
            recipe.AddIngredient(ItemID.MudBlock, 50);
            recipe.AddIngredient(ItemID.Ectoplasm, 4);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }

        public override bool? UseItem(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                playersUsingProjectile.Add(player.whoAmI);
            }
            return null;
        }

        public static List<int> playersUsingProjectile = new();

        public override bool CanUseItem(Player player)
        {
            return !playersUsingProjectile.Contains(player.whoAmI);
        }

        
    }
}
