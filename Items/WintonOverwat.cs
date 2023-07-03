using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using JoJosMod.Projectiles;
using Terraria.DataStructures;
using System.Collections.Generic;

namespace JoJosMod.Items
{
    internal class WintonOverwat : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Winton Overwat");
            Tooltip.SetDefault("Winton.");
        }

        public override void SetDefaults()
        {
            Item.width = 48; Item.height = 44;
            Item.DamageType = DamageClass.Generic;
            Item.damage = 420;
            Item.knockBack = 2;
            Item.holdStyle = ItemHoldStyleID.HoldUp;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.noMelee = true;
            Item.useAnimation = 10;
            Item.useTime = 10;
            Item.shoot = ModContent.ProjectileType<WintonProjectile>();
            Item.shootSpeed = 35;
            Item.knockBack = 10;
            Item.rare = ItemRarityID.Red;
            Item.value = 220000;
            
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {

            Projectile.NewProjectile(Item.GetSource_FromThis(),new(Main.MouseWorld.X, player.position.Y -1000), new(0,Item.shootSpeed), ModContent.ProjectileType<WintonProjectile>(),damage, knockback, Main.myPlayer, 0f, 0f) ;
            return false;
        }

        public override bool? UseItem(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                playersUsingProjectile.Add(Main.myPlayer);
            }
            return null;
        }

        public static List<int> playersUsingProjectile = new();

        public override bool CanUseItem(Player player)
        {
            return !playersUsingProjectile.Contains(player.whoAmI);
        }
    }
}
