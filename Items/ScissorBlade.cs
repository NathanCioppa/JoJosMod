using System.Numerics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using JoJosMod.Projectiles;

namespace JoJosMod.Items
{
    internal class ScissorBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Scissor Blade");
            Tooltip.SetDefault("Ignores 25 points of enemy defense");
        }

        public override void SetDefaults()
        {
            Item.width = 116; Item.height = 116;
            Item.damage = 70;
            Item.DamageType = DamageClass.Melee;
            Item.useTime = 8;
            Item.useAnimation = 16;
            Item.knockBack = 5;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<ScissorBladeProjectile>();
            Item.shootSpeed = 1;
            Item.scale = 1;
            Item.ArmorPenetration = 25;
            Item.rare = ItemRarityID.Yellow;
        }
    }
}
