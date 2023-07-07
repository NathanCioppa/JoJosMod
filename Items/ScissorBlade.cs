using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using JoJosMod.Projectiles;
using Terraria.DataStructures;

namespace JoJosMod.Items
{
    internal class ScissorBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Scissor Blade");
            Tooltip.SetDefault("Ignores 25 points of enemy defense");
        }

        public static int UseTime = 20; 

        public override void SetDefaults()
        {
            Item.width = 116; Item.height = 118;
            Item.damage = 70;
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
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {

            Projectile.NewProjectile(Item.GetSource_FromThis(), player.Center, new(0,0), ModContent.ProjectileType<ScissorBladeProjectile>(), 0, 0, Main.myPlayer, 0f, 0f);
            return true;
        }
    }
}
