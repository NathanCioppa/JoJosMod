using JoJosMod.Items;
using System.Numerics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

// Responsible for burning and knocking back enemies when the Expolsion Staff item is used

namespace JoJosMod.Projectiles
{
    internal class ExplosionStaffShockwave : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.timeLeft = ExplosionStaff.UseTime;
            Projectile.ignoreWater = true;
            Projectile.penetrate = -1;
            Projectile.width = 3000; Projectile.height = 3000;
            Projectile.damage = 1;
            Projectile.tileCollide = false;
        }


        Vector2 explosionCenter;
        public override void OnSpawn(IEntitySource source)
        {
            explosionCenter = new(Projectile.ai[0], Projectile.ai[1]);
        }


        public override void AI()
        {
            if (Main.player[Projectile.owner].dead) Projectile.Kill();
        }


        public override bool? CanHitNPC(NPC target)
        {
            return Projectile.timeLeft <= 3 && !target.isLikeATownNPC;
        }
        
        
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.OnFire, 1000);

            // Push enemies away from the explosion
            if (target.type == NPCID.TargetDummy) return; // Prevent from moving a target dummy's hitbox
            target.velocity.X += target.position.X >= explosionCenter.X ? 4 : -4;
            target.velocity.Y += target.position.Y >= explosionCenter.Y ? 4 : -4;
        }
    }
}
