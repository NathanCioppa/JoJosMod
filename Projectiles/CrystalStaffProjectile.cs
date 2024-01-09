using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using JoJosMod.Helpers;
using System;
using Terraria.DataStructures;

namespace JoJosMod.Projectiles
{
    internal class CrystalStaffProjectile : ModProjectile
    {
        const int MaxAnimationFrames = 5;

        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = MaxAnimationFrames;
        }

        public override void SetDefaults()
        {
            Projectile.width = 4; Projectile.height = 3;
            Projectile.damage = 10;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ArmorPenetration = 20;
            Projectile.penetrate = 4;
            Projectile.timeLeft = 300;
            Projectile.frame = new Random().Next(0, MaxAnimationFrames + 1);
        }



        Vector2 projectileSpawn;
        int rotationDirection;
        
        readonly Random rnd = new();
        readonly int[] lights = { TorchID.Red, TorchID.Orange, TorchID.Yellow, TorchID.Green, TorchID.Blue, TorchID.Purple };
        int light;

        public override void OnSpawn(IEntitySource source)
        {
            projectileSpawn = Main.player[Projectile.owner].Center;
            Projectile.velocity = new(Projectile.velocity.X + new Random().Next(-1, 1), Projectile.velocity.Y + new Random().Next(-1, 1));
            rotationDirection = rnd.Next(0, 2) == 0 ? -1 : 1;
            light = lights[rnd.Next(0, lights.Length)];
        }

        

        // Used to start spawning dust only when the projectile is at or farther from the player than the tip of the staff sprite
        const int StaffTipCenterXY = 52; // middle of the tip of the staff sprite is 52 pixles right and up from bottom left of the sprite
        readonly double staffTipMiddleDistFromPlayer = Math.Sqrt(Math.Pow(StaffTipCenterXY, 2) * 2);

        readonly int[] gemDusts = { DustID.GemRuby, DustID.GemTopaz, DustID.GemAmber, DustID.GemEmerald, DustID.GemSapphire, DustID.GemAmethyst };

        public override void AI()
        {
            Projectile.velocity *= new Vector2(0.99f, 0.99f); // Gradually slows projectile
            Projectile.rotation += 0.5f * rotationDirection;
            
            if (JoJosMath.Distance(Projectile.position, projectileSpawn) >= staffTipMiddleDistFromPlayer)
            {
                Dust dust = Dust.NewDustPerfect(
                    Projectile.position, 
                    gemDusts[rnd.Next(0, gemDusts.Length)], 
                    new(rnd.Next(-5,5), -rnd.Next(-5,5)), 
                    Scale: 0.75f
                );
                dust.noGravity = true;
            }
            
            Lighting.AddLight(Projectile.Center, light);
        }



        // Bounce off tiles
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (Projectile.velocity.X != oldVelocity.X) Projectile.velocity.X = -oldVelocity.X;
            if (Projectile.velocity.Y != oldVelocity.Y) Projectile.velocity.Y = -oldVelocity.Y;

            return false;
        }



        // Lower target immunity for higher dps
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.immune[Projectile.owner] = 5;
        }
    }
}
