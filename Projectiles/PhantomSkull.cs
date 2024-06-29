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
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.frame = 0;
            Projectile.damage = 50;
            Projectile.light = 0.75f;
        }

        const float homingRange = 500f;
        const float homingTurnRadius = 0.1f;
        float speed; // set in AI() to the initial speed of the projectile, since it is randomized when shot.

        public override void AI()
        {
            if (Projectile.ai[0] == 0) 
                speed = (float)Math.Sqrt((Projectile.velocity.X * Projectile.velocity.X) + (Projectile.velocity.Y * Projectile.velocity.Y));

            Projectile.ai[0] += 1f;


            // Logic for homing in on the nearest enemy in range
            int closestEnemyIndex = Projectile.FindTargetWithLineOfSight(maxRange: homingRange);
            if(closestEnemyIndex != -1) Projectile.velocity = 
                Vector2.Lerp(
                    Projectile.velocity, 
                    Projectile.DirectionTo(Main.npc[closestEnemyIndex].Center) * speed, 
                    homingTurnRadius
                );
                
            IncrementAnimationFrame(Projectile, 5, MaxAnimationFrames);

            // Correct the sprite's rotation 
            Projectile.rotation = Projectile.velocity.ToRotation();
            if (Projectile.direction < 0) Projectile.rotation += MathHelper.Pi;
            Projectile.spriteDirection = -Projectile.direction; // negative cuz i drew it the wrong direction :3
        }

        public static void IncrementAnimationFrame(Projectile projectile, int interval, int maxAnimationFrames)
        {
            if (projectile.ai[0] % interval != 0) return;
            
            projectile.frame++;
            if (projectile.frame >= maxAnimationFrames) projectile.frame = 0;
        }
    }
}
