using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using JoJosMod.Projectiles;
using Terraria.DataStructures;
using JoJosMod.Dusts;
using System;
using JoJosMod.Players;


namespace JoJosMod.Buffs
{
    internal class ExplosionMagicDebuff : ModBuff
    {
        public override void Update(Player player, ref int buffIndex)
        {
            
            player.GetModPlayer<ExplosionMagicDebuffPlayer>().explosionMagicExhausted = true;
        }
    }
}
