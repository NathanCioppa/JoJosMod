using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using JoJosMod.Helpers;
using System;
using Terraria.DataStructures;

namespace JoJosMod.Projectiles
{
    internal class PhantomSkull : ModProjectile
    {
        const int MaxAnimationFrames = 5;

        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = MaxAnimationFrames;
        }

        public override void SetDefaults()
        {
            Projectile.width = 26; Projectile.height = 32;
            Projectile.frame = 0;
        }

        public override void AI()
        {
            Projectile.frame = Projectile.frame >= MaxAnimationFrames - 1 ? 0: Projectile.frame + 1;
            Projectile.rotation = Projectile.velocity.ToRotation();
            if (Projectile.direction < 0) Projectile.rotation += MathHelper.Pi;
            Projectile.spriteDirection = -Projectile.direction;
        }
    }
}
