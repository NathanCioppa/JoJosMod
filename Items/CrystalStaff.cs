using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using JoJosMod.Projectiles;

namespace JoJosMod.Items
{
    internal class CrystalStaff : ModItem
    {
        public const int ItemWidthHeight = 56;

        public override void SetStaticDefaults()
        {
            Item.staff[Type] = true;
        }

        public override void SetDefaults()
        {
            Item.height = ItemWidthHeight; Item.width = ItemWidthHeight;
            Item.damage = 70;
            Item.DamageType = DamageClass.Magic;
            Item.ArmorPenetration = 20;
            
            Item.useAnimation = 2;
            Item.useTime = 2;
            Item.autoReuse = true;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            
            Item.shoot = ModContent.ProjectileType<CrystalStaffProjectile>();
            Item.shootSpeed = 35;
            
            Item.UseSound = SoundID.Item9;
        }
    }
}
