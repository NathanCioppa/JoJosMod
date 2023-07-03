using Microsoft.Xna.Framework;
using Terraria.Audio;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ID;
using JoJosMod.Items;

namespace JoJosMod.Projectiles
{
    internal class WintonProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Winton");
        }

        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Generic;
            Projectile.width = 500; Projectile.height = 441;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.timeLeft = 500;
            Projectile.ignoreWater = true;
            Projectile.penetrate = 30;
            Projectile.light = 0.5f;
            Projectile.damage = 300;
            Projectile.knockBack = 2;
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough, ref Vector2 hitboxCenterFrac)
        {
            width = (int)(Projectile.width * 0.7f); height = (int)(Projectile.height * 0.7f);
            return true;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.velocity = new(0, 0);
            return false;
        }

        public override void OnSpawn(IEntitySource source)
        {
            SoundEngine.PlaySound(SoundID.MoonLord);
        }

        public override bool? CanHitNPC(NPC target)
        {
            Projectile.penetrate++;
            return base.CanHitNPC(target);
        }

        public override void Kill(int timeLeft)
        {
            WintonOverwat.playersUsingProjectile.Remove(Projectile.owner);
        }
    }
}
