
using Terraria.ModLoader;

namespace JoJosMod.Players
{
    internal class SymphonyHatPlayer:ModPlayer
    {
        public bool isWearingShmphonyHat;

        public override void ResetEffects()
        {
            isWearingShmphonyHat = false;
        }
    }
}
