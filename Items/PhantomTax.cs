using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using JoJosMod.Projectiles;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using System;

namespace JoJosMod.Items
{
    
    internal class PhantomTax : ModItem
    {
        // The percent of shootSpeed, as a decimal, that will be added to or subtracted from the final X and Y velocity of the projectile.
        // A larger absolute value means a greater max and lower min speed, as well as a wider spread. 
        // Ex: shootSpeed of 8 and VelocityRandomnessFactor of 0.25 means the X and Y velocitys will have between -2 and 2 added before being shot.
        const float VelocityRandomnessFactor = 0.25f;

        private static readonly Random random = new();

        public override void SetDefaults()
        {
            Item.width = 20; Item.height = 30;
            Item.rare = ItemRarityID.Red;
            Item.value = Item.sellPrice(gold: 10);
            
            Item.damage = 50;
            Item.DamageType = DamageClass.Magic;
            Item.mana = 8;
            Item.autoReuse = true;
            
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useTime = 10;
            Item.useAnimation = 10;
            
            Item.shoot = ModContent.ProjectileType<PhantomSkull>();
            Item.shootSpeed = 15;
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            float randomnessRange = VelocityRandomnessFactor * Item.shootSpeed;

            velocity += new Vector2(
                ((float) random.NextDouble() * (randomnessRange * 2)) - randomnessRange,
                ((float) random.NextDouble() * (randomnessRange * 2)) - randomnessRange
            );

        }
    }
}
