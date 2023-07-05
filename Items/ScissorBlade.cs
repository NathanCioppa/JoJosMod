﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using JoJosMod.Projectiles;
using Terraria.DataStructures;
using System.Collections.Generic;

namespace JoJosMod.Items
{
    internal class ScissorBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Scissor Blade");
            Tooltip.SetDefault("Ignores 25 points of enemy defense");
        }

        public override void SetDefaults()
        {
            Item.width = 116; Item.height = 118;
            Item.damage = 70;
            Item.DamageType = DamageClass.Melee;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.knockBack = 4;
            Item.noUseGraphic = true;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<Projectiles.ScissorBlade>();
            Item.shootSpeed = 1;
            Item.scale = 1;
            Item.ArmorPenetration = 25;
            Item.rare = ItemRarityID.Yellow;
        }
    }
}
