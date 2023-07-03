﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using JoJosMod.Items;
using Terraria.DataStructures;

namespace JoJosMod.Projectiles
{
    internal class ShrekDiscProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cinematic Masterpiece");
        }

        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Melee;
            Projectile.width = 70; Projectile.height = 70;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.timeLeft = 600;
            Projectile.ignoreWater = false;
            Projectile.penetrate = 5;
            Projectile.light = 0.5f;
        }

        const float SecondsBeforeReturning = 0.5f;
        public bool isReturning = false;
        public bool shouldTurnAround = false;
        const float TurnAroundStateLengthSeconds = 0.2f;
        float playerAttackSpeed = Main.player[Main.myPlayer].GetAttackSpeed<MeleeDamageClass>();
        int spin = 1;
        

        public override void AI()
        {
            Projectile.ai[0] += 1f;
            float secondsSinceThrow = Projectile.ai[0] / 60f;

            if (!isReturning)
            {
                isReturning = secondsSinceThrow >= SecondsBeforeReturning;
                if (isReturning) shouldTurnAround = true;

                spin = Projectile.direction;
                Projectile.damage += (int)(Projectile.damage * 0.03f);
            }
            Projectile.rotation += 0.3f * spin;

            if (isReturning)
            {
                Projectile.ai[1] += 1f;
                float secondsSinceStartReturning = Projectile.ai[1] / 60f;

                shouldCollide = false;

                Player player = Main.player[Main.myPlayer];
                Vector2 playerLocation = player.position;
                
                // Calculate the distance between the disc and the player
                float distanceFromDestinationX = (playerLocation.X + (player.width * 0.5f)) - Projectile.Center.X;
                float distanceFromDestinationY = (playerLocation.Y + (player.height * 0.5f)) - Projectile.Center.Y;
                float distanceFromDestination = (float)System.Math.Sqrt( (double) ((distanceFromDestinationX * distanceFromDestinationX) + (distanceFromDestinationY * distanceFromDestinationY) ));

                // If disc has reached the player, kill the projectile
                if(distanceFromDestination <= Projectile.width/2) Projectile.Kill();

                // baseSpeed is the same speed at which the disc traveled when it was thrown
                float baseSpeed = (ShrekDisc.throwVelocity * playerAttackSpeed) /distanceFromDestination;
                float speedMultiplier = 1.2f;
                float speed = baseSpeed * speedMultiplier;

                float newVelocityX = (secondsSinceStartReturning <= TurnAroundStateLengthSeconds && shouldTurnAround) 
                    ? distanceFromDestinationX * (baseSpeed * ( (1f / TurnAroundStateLengthSeconds) * secondsSinceStartReturning )) 
                    : distanceFromDestinationX * speed;

                Vector2 velocity = new(newVelocityX, distanceFromDestinationY * speed);

                Projectile.velocity =  velocity;

                Projectile.damage += (int)(Projectile.damage * 0.01f);
            }
        }

        public int bounces = 0;
        public const int MaxBounces = 6;

        public bool shouldCollide = true;

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough, ref Vector2 hitboxCenterFrac)
        {
            width = (int)(Projectile.width * 0.3f); height = (int)(Projectile.height * 0.3f);

            return shouldCollide;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            bounces++;
            if (bounces > MaxBounces)
            {
                isReturning = true;
                shouldCollide = false;
                return false;
            }

            if (Projectile.velocity.X != oldVelocity.X) Projectile.velocity.X = -oldVelocity.X;
            if (Projectile.velocity.Y != oldVelocity.Y) Projectile.velocity.Y = -oldVelocity.Y;

            return false;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Projectile.penetrate++;
            isReturning = true;
        }

        public override void Kill(int timeLeft)
        {
            ShrekDisc.playersUsingProjectile.Remove(Projectile.owner);
        }
    }
}