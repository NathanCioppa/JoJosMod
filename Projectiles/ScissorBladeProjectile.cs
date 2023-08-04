using System.Numerics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using System;
using Microsoft.Xna.Framework;
using JoJosMod.Items;

namespace JoJosMod.Projectiles;

    internal class ScissorBladeProjectile : ModProjectile
    {

    const int MaxAnimationFrames = 9;
    public override void SetStaticDefaults()
    {
        Main.projFrames[Projectile.type] = MaxAnimationFrames;
    }

    const float BaseRotation = 1.3f;

    public override void SetDefaults()
    {
        Projectile.width = 136; Projectile.height = 136;
        Projectile.timeLeft = Items.ScissorBlade.UseTime;
        Projectile.penetrate = 100;
        Projectile.tileCollide = false;
        Projectile.friendly = true;
        Projectile.hostile = false;
        Projectile.ignoreWater = true;
        Projectile.spriteDirection = swingDirection;
        Projectile.rotation = BaseRotation * -swingDirection;
    }

    readonly Player thisPlayer = Main.player[Main.myPlayer];

    public int swingDirection = Main.MouseWorld.X >= Main.player[Main.myPlayer].Center.X ? 1 : -1;

    float additionalRotation = 0;
    const float BaseAdditionalScale = 0.25f;

    public override void AI()
    {
        Projectile.frameCounter++;
        Projectile.scale = thisPlayer.GetAdjustedItemScale(thisPlayer.HeldItem) + BaseAdditionalScale;

        additionalRotation += MathHelper.Pi / (Items.ScissorBlade.UseTime - 1);

        if (additionalRotation < MathHelper.PiOver2)
        Projectile.rotation += MathHelper.Pi / (Items.ScissorBlade.UseTime - 1) * swingDirection;

        if (Projectile.frameCounter % (Items.ScissorBlade.UseTime/MaxAnimationFrames) == 0 && Projectile.frame < MaxAnimationFrames-1)
        {
            Projectile.frame++;
        }
        if(Projectile.frame >= MaxAnimationFrames - 1)
        {
            Projectile.Kill();
        }

        Projectile.position = new((thisPlayer.Center.X - (swingDirection == 1 ? 0 : Projectile.width))+0, thisPlayer.Center.Y - (Projectile.height / 2));

        DrawOriginOffsetX = (Projectile.width / 2) * -swingDirection;
        DrawOriginOffsetY = -Projectile.height/2;
    }
}
