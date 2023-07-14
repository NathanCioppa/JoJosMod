using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using JoJosMod.Projectiles;
using Terraria.DataStructures;
using System.Reflection.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JoJosMod.Dusts
{
    internal class WhiteStar : ModDust
    {
        public readonly static int whiteStarWidthHeight = 20;
        float baseRotation = 0;
        int baseRotationDirction = 1;
        const float MaxScale = 2;
        

        public override void OnSpawn(Dust dust)
        {
            dust.noGravity = true;
            dust.frame = new Rectangle(0, 0, whiteStarWidthHeight, whiteStarWidthHeight);

            if (new Random().Next(2) == 0)
                baseRotationDirction *= -1;
            
            baseRotation = (MathHelper.PiOver2 / new Random().Next(1, 11)) * baseRotationDirction;

            dust.rotation = baseRotation;
        }


        List<int> shrinkingDust = new();

        public override bool Update(Dust dust)
        {
            if (dust.scale < MaxScale && !shrinkingDust.Contains(dust.dustIndex))
            {
                dust.scale += 0.1f;
                
            }
            else
            {
                if(!shrinkingDust.Contains(dust.dustIndex)) shrinkingDust.Add(dust.dustIndex);
                dust.scale -= 0.1f;
            }
            
            if (dust.scale < 0.75f)
            {
                shrinkingDust.Remove(dust.dustIndex);
                dust.active = false;
            }
            return false;
        }
    }
}
