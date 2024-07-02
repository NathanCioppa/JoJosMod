using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace JoJosMod.Projectiles
{
    public class SayoriProjectile : ModProjectile
    {

        public override void SetDefaults()
        {
            Projectile.width = 16; Projectile.height = 16;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.timeLeft = 600;
            Projectile.light = 0.5f;
            Projectile.penetrate = 2;
            Projectile.knockBack = 3;
            Projectile.ignoreWater = false;
        }

        public int timeSinceThrow = 0;
        public float startWorldLocation = Main.LocalPlayer.position.X;


        public override void AI()
        {
            timeSinceThrow++;
           
            
            Projectile.ai[0] += 1f;

            if (Projectile.ai[0] >= 30f || numberOfCollisions > 0)
            {
                Projectile.velocity.Y += 0.8f;
                Projectile.rotation += startWorldLocation <= Projectile.position.X ? 0.4f : -0.4f;
                
            }
            else
            {
                Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            }

            if (Projectile.velocity.Y >= 16f)
            {
                Projectile.velocity.Y = 16f;
            }
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough, ref Vector2 hitboxCenterFrac)
        {
            width = Projectile.width - 2; height = Projectile.height - 2;
            return true;
        }

        int numberOfCollisions = 0;

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            SoundEngine.PlaySound(SoundID.FemaleHit, Projectile.position);
            numberOfCollisions++;

            if(numberOfCollisions <= 3)
            {
                if(Projectile.velocity.X != oldVelocity.X) Projectile.velocity.X = -oldVelocity.X;
                if(Projectile.velocity.Y != oldVelocity.Y) Projectile.velocity.Y = -oldVelocity.Y;
            } 
            else
            {
                Projectile.Kill();
            }

            return false;
        }
    }
}