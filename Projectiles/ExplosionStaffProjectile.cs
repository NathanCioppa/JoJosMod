using JoJosMod.Items;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

// Damaging explosion spawned from the Explsion Staff item's attack

namespace JoJosMod.Projectiles
{
    internal class ExplosionStaffProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Magic;
            Projectile.width = 500; Projectile.height = 600;
            Projectile.damage = 200;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.timeLeft = ExplosionStaff.UseTime;
            Projectile.ignoreWater = true;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
        }


        Vector2 blastCenter; 
        Vector2 blastPosition; // Set in OnSpawn() to the position of the top-left corner of the blast

        public override void OnSpawn(IEntitySource source)
        {
            blastCenter = new(Projectile.ai[0], Projectile.ai[1]);
            blastPosition = new(blastCenter.X - (Projectile.width / 2), blastCenter.Y - (Projectile.height / 2));
        }
        
        
        bool soundPlayed = false;
        bool isExploding = false;
        public override void AI()
        {
            if (Main.player[Projectile.owner].dead)
            {
                Projectile.Kill();
                return;
            }

            isExploding = Projectile.timeLeft <= 3;

            if (!isExploding) return; // Code below is only run during the explosion

            if (!soundPlayed)
            {
                SoundEngine.PlaySound(SoundID.DD2_BetsyFireballImpact, blastCenter);
                soundPlayed = true;
            }

            // Spawn dust for explosion visuals
            for (int i = 0; i < 200; i++)
            {
                Dust.NewDust(
                    new Vector2(blastCenter.X - 50, blastCenter.Y - 50),
                    100,
                    100,
                    DustID.SolarFlare,
                    SpeedX: 4 * (i%2==0? -1:1),
                    SpeedY: -8 * (i%4==0? 1.5f:1),
                    Scale: 2 * (i%5==0? .5f : 1)
                );

                Dust.NewDust(
                    new Vector2(blastCenter.X - 50, blastCenter.Y - 50),
                    100,
                    100,
                    DustID.SolarFlare,
                    SpeedX: (i%2==0? -1:1),
                    SpeedY: -10 * (i%4==0? 1.5f:1),
                    Scale: 2 * (i%5==0? .5f:1)
                );

                Dust.NewDust(
                    new Vector2(blastCenter.X - 50, blastCenter.Y - 25),
                    100,
                    100,
                    DustID.SolarFlare,
                    SpeedX: (i%2==0? -1:1),
                    SpeedY: -5 * (i%4==0? 1.5f:1),
                    Scale: 2 * (i%5==0? .5f:1)
                );


                Dust.NewDust(
                    blastPosition,
                    Projectile.width,
                    Projectile.height,
                    DustID.Smoke,
                    SpeedX: 15 * (i%2==0? -1:1) * (i%5==0? 0:1), 
                    SpeedY: -2,
                    newColor: new Color(0,0,0),
                    Alpha: 50,
                    Scale: 1.25f * (i%6==0? 1.5f:1)
                );

                Dust.NewDust(
                    blastPosition,
                    Projectile.width,
                    (int)(Projectile.height / 1.5f),
                    DustID.FlameBurst
                );

                Dust.NewDust(
                    blastPosition,
                    Projectile.width,
                    (int)(Projectile.height / 1.5f),
                    DustID.FlameBurst
                );
            }
        }


        public override bool? CanHitNPC(NPC target)
        {
            return isExploding && !target.isLikeATownNPC;
        }


        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.CursedInferno, 2000);
            target.AddBuff(BuffID.BrokenArmor, 2000);
            target.AddBuff(BuffID.BetsysCurse, 2000);
        }
    }
}
