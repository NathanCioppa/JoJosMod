using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using JoJosMod.Projectiles;

namespace JoJosMod.Items
{
    internal class PhantomTax : ModItem
    {
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.shoot = ModContent.ProjectileType<PhantomSkull>();
            Item.shootSpeed = 5;
            Item.useTime = 3;
            Item.useAnimation = 3;
        }
    }
}
