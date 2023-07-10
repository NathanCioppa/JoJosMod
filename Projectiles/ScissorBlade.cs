using System.Numerics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using System;
using JoJosMod.Items;
using Microsoft.Xna.Framework;

namespace JoJosMod.Projectiles
{
    internal class ScissorBlade : ModProjectile
    {
        const int MaxAnimationFrames = 5;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Scissor Blade");
            Main.projFrames[Projectile.type] = MaxAnimationFrames;
        }

        float baseRotation;
        public override void SetDefaults()
        {
            baseRotation = -swingDirection * 1.9f;
            Projectile.width = 116; Projectile.height = 118;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.timeLeft = (int)(Items.ScissorBlade.UseTime / thisPlayer.GetTotalAttackSpeed<MeleeDamageClass>());
            Projectile.penetrate = 100;
            Projectile.tileCollide = false;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.spriteDirection = swingDirection;
            Projectile.rotation = baseRotation;
        }

        readonly Player thisPlayer = Main.player[Main.myPlayer];

        // 1 for right, -1 for left
        public int swingDirection = Main.MouseWorld.X >= Main.player[Main.myPlayer].Center.X ? 1 : -1;

        public override void AI()
        {
            Projectile.ai[0]++;
            Projectile.frameCounter++;

            if (Projectile.frameCounter % Math.Floor((decimal)Items.ScissorBlade.UseTime / MaxAnimationFrames) == 0 && Projectile.frame < MaxAnimationFrames - 1)
            {
                Projectile.frame++;
            }
            Projectile.damage = 0;
            Projectile.knockBack = 0;

            if (Projectile.ai[0] > 1)
                Projectile.rotation += (MathHelper.Pi / (int)((Items.ScissorBlade.UseTime - 1) / thisPlayer.GetTotalAttackSpeed<MeleeDamageClass>())) * swingDirection;
            
            if(Projectile.ai[0] == (int)(Items.ScissorBlade.UseTime / thisPlayer.GetTotalAttackSpeed<MeleeDamageClass>())-1)
                Projectile.rotation = baseRotation + ((MathHelper.Pi - 0.25f) * swingDirection);

            Projectile.velocity = new(0,0);

            Projectile.scale = thisPlayer.GetAdjustedItemScale(thisPlayer.HeldItem);

            Projectile.position = new(thisPlayer.Center.X - (swingDirection == 1 ? 0:Projectile.width), thisPlayer.Center.Y - (Projectile.height/2));

            DrawOriginOffsetX = (Projectile.width / 2) * -swingDirection;
            DrawOriginOffsetY = -Projectile.height / 2;
            
            

        }

    }
}
