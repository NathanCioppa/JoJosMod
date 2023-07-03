using System.Numerics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace JoJosMod.Projectiles
{
    internal class ScissorBladeProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Scissor Blade");
        }

        public override void SetDefaults()
        {
            Projectile.width = 136; Projectile.height = 136*2;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.timeLeft = 8;
            Projectile.penetrate = 100;
            Projectile.tileCollide = false;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;

        }

        readonly Player thisPlayer = Main.player[Main.myPlayer];

        public bool isRightSwing = Main.MouseWorld.X >= Main.player[Main.myPlayer].Center.X;

        public override void AI()
        {
            Projectile.rotation = isRightSwing ? -1.2f : -1.9f; //-1.9
            Projectile.velocity = new(0,0);

            Projectile.scale = thisPlayer.GetAdjustedItemScale(thisPlayer.HeldItem) + 0.2f;

            Projectile.position = new(thisPlayer.Center.X - (isRightSwing ? 40 : 90), thisPlayer.Center.Y - (Projectile.height / 1.3f)); //90
           
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            SoundEngine.PlaySound(SoundID.FemaleHit, thisPlayer.position);
        }

    }
}
