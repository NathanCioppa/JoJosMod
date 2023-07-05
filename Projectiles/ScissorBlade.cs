using System.Numerics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using System;
using Microsoft.Xna.Framework;

namespace JoJosMod.Projectiles
{
    internal class ScissorBlade : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Scissor Blade");
            Main.projFrames[Projectile.type] = 5;
        }

        public override void SetDefaults()
        {
            Projectile.width = 116; Projectile.height = 118;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.timeLeft = 15;
            Projectile.penetrate = 100;
            Projectile.tileCollide = false;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.spriteDirection = isRightSwing ? 1:-1;
            Projectile.rotation = isRightSwing ? -2f :2f;
        }

        readonly Player thisPlayer = Main.player[Main.myPlayer];

        public bool isRightSwing = Main.MouseWorld.X >= Main.player[Main.myPlayer].Center.X;


        public override void AI()
        {
            Projectile.frameCounter++;

            if (Projectile.frameCounter %3 == 0)
            {
                Projectile.frame++;
            }
            Projectile.damage = 0;
            Projectile.knockBack = 0;

            if (Projectile.ai[0] > 0)Projectile.rotation += isRightSwing ? MathHelper.Pi / 14: -MathHelper.Pi / 14;
            Projectile.velocity = new(0,0);

            Projectile.scale = thisPlayer.GetAdjustedItemScale(thisPlayer.HeldItem);

            Projectile.position = new(thisPlayer.Center.X - (isRightSwing ? 0:Projectile.width), thisPlayer.Center.Y - (Projectile.height/2));

            DrawOriginOffsetX = isRightSwing ? -Projectile.width/2 : Projectile.width/2;
            DrawOriginOffsetY = isRightSwing ?  -Projectile.height/2 : -Projectile.width/2;
            
            Projectile.ai[0]++;

        }

    }
}
