using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using JoJosMod.Projectiles;
using Terraria.Audio;
using JoJosMod.Players;
using JoJosMod.Buffs;

namespace JoJosMod.Items
{
    internal class ExplosionStaff : ModItem
    {
        public const int UseTime = 300;
        public override void SetDefaults()
        {
            Item.width = 76;
            Item.height = 88;
            Item.damage = 200;
            Item.DamageType = DamageClass.Magic;
            Item.mana = 100;
            Item.holdStyle = ItemHoldStyleID.HoldGuitar;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.noMelee = true;
            Item.useTime = UseTime;
            Item.useAnimation = UseTime;
            Item.rare = ItemRarityID.Red;
        }
        

        public override void UseStyle(Player player, Rectangle heldItemFrame)
        {
            player.itemRotation = -(MathHelper.Pi/3) * player.direction;
            player.itemLocation.X -= 10 * player.direction;
        }


        int useTicks = 0; //tracks time that item has been in use for in its most recent use
        Vector2 blastCenter;
        Vector2 defaultDustVelocity = new(10, 0);

        public override bool? UseItem(Player player)
        {
            if(player.ItemAnimationJustStarted)
            {
                blastCenter = Main.MouseWorld;

                // Spawn the actual explosion projectile
                Projectile.NewProjectile(
                    Item.GetSource_FromThis(), 
                    new(blastCenter.X, blastCenter.Y - 50), // Offset from center so that the explosion damages slightly farther above than below 
                    new(0,0), 
                    ModContent.ProjectileType<ExplosionStaffProjectile>(), 
                    Item.damage, 
                    0, 
                    Main.myPlayer,
                    // Pass the x and y coordinates of the center of the explosion into ai0 and ai1 respectively, for all projectiles spawned from this item
                    ai0: blastCenter.X, 
                    ai1: blastCenter.Y
                );

                // Spawn the explosion "shockwave" which knockbacks and burns enemies in a larger range than the main explosion
                Projectile.NewProjectile(
                    Item.GetSource_FromThis(),
                    blastCenter,
                    new(0, 0),
                    ModContent.ProjectileType<ExplosionStaffShockwave>(),
                    1,
                    0,
                    Main.myPlayer,
                    ai0: blastCenter.X,
                    ai1: blastCenter.Y
                );

                SoundEngine.PlaySound(SoundID.Pixie);

                player.AddBuff(ModContent.BuffType<ExplosionMagicDebuff>(), 1800);

                useTicks = 0;
            }

            useTicks++;

            // Spawn lines of dust for pre-explosion effect

            SpawnDustLine(0,defaultDustVelocity);

            if (useTicks >= UseTime / 8)
            {
                SpawnDustLine(-100, defaultDustVelocity);
                SpawnDustLine(-100, defaultDustVelocity * 2);
            }

            if(useTicks >= (UseTime / 8) * 2)
                SpawnDustLine(-200, defaultDustVelocity);

            if(useTicks >= (UseTime / 8) * 3)
            {
                SpawnDustLine(-300, defaultDustVelocity);
                SpawnDustLine(-300, defaultDustVelocity * 3);

                Dust.NewDust( // Dust that shoots up from bottom
                    new(blastCenter.X, 
                    blastCenter.Y + 50), 
                    0, 
                    0, 
                    DustID.SolarFlare, 
                    SpeedX: 0, 
                    SpeedY: -15, 
                    Scale: 2f
                );
            }

            return null;
        }


        public override bool CanUseItem(Player player)
        {
            return !player.GetModPlayer<ExplosionMagicDebuffPlayer>().explosionMagicExhausted;
        }


        public void SpawnDustLine(int spawnOffsetY, Vector2 velocity)
        {
            Dust.NewDustPerfect(new(blastCenter.X, blastCenter.Y + spawnOffsetY), DustID.SolarFlare, Velocity: velocity, Scale: 2f).noGravity = true;
            Dust.NewDustPerfect(new(blastCenter.X, blastCenter.Y + spawnOffsetY), DustID.SolarFlare, Velocity: -velocity, Scale: 2f).noGravity = true;
        }
    }
}
