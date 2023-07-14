using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using JoJosMod.Projectiles;
using Terraria.DataStructures;
using JoJosMod.Dusts;

namespace JoJosMod.Items
{
    internal class ScissorBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Scissor Blade");
            Tooltip.SetDefault("Ignores 25 points of enemy defense \n\"Swiss cheese!\"");
        }

        public static int UseTime = 15; 

        public override void SetDefaults()
        {
            Item.width = 116; Item.height = 118;
            Item.damage = 190;
            Item.DamageType = DamageClass.Melee;
            Item.useTime = UseTime;
            Item.useAnimation = UseTime;
            Item.knockBack = 4;
            Item.noUseGraphic = true;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<Projectiles.ScissorBlade>();
            Item.shootSpeed = 1;
            Item.scale = 1;
            Item.ArmorPenetration = 25;
            Item.rare = ItemRarityID.Yellow;
            Item.crit = 30;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {

            Projectile.NewProjectile(Item.GetSource_FromThis(), player.Center, new(0,0), ModContent.ProjectileType<ScissorBladeProjectile>(), 0, 0, Main.myPlayer, 0f, 0f);
            return true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.StylistKilLaKillScissorsIWish, 1);
            recipe.AddIngredient(ItemID.BrokenHeroSword,1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            Vector2 spawnPosition = new( (target.position.X - (WhiteStar.whiteStarWidthHeight/2)), (target.position.Y - (WhiteStar.whiteStarWidthHeight/2)) );
            

            Dust.NewDust(spawnPosition, target.width, target.height, ModContent.DustType<WhiteStar>(), Scale: 1.5f);
        }
    }
}
