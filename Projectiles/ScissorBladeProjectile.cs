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
            Main.projFrames[Projectile.type] = 3;
        }

        public override void SetDefaults()
        {
            Projectile.width = 136; Projectile.height = 136*2;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.timeLeft = 15;
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
            Projectile.frameCounter++;
            if(Projectile.frameCounter % 5 == 0)
            {
                Projectile.frame++;
            }
            Projectile.rotation = isRightSwing ? -1.2f : 4.4f;
            Projectile.velocity = new(0,0);

            Projectile.scale = thisPlayer.GetAdjustedItemScale(thisPlayer.HeldItem) + 0.2f;

            Projectile.position = new((thisPlayer.position.X - (isRightSwing ? 40 : 90)), (thisPlayer.Center.Y - (Projectile.height / 1.3f)));

        }

    }
}
