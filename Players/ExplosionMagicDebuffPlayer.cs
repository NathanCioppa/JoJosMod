
using System.Net.Http.Headers;
using Terraria;
using Terraria.ModLoader;

namespace JoJosMod.Players
{
    internal class ExplosionMagicDebuffPlayer : ModPlayer
    {
        public bool explosionMagicExhausted;

        public override void ResetEffects()
        {
            explosionMagicExhausted = false;
        }
    }
}
