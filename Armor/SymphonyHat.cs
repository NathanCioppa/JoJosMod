
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using JoJosMod.Players;

namespace JoJosMod.Armor
{
    [AutoloadEquip(EquipType.Head)]
    internal class SymphonyHat : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 30; Item.height = 46;
            Item.vanity = true;
        }

        public override void SetStaticDefaults()
        {
            ArmorIDs.Head.Sets.DrawHatHair[Item.headSlot] = true;
        }

        public override bool IsVanitySet(int head, int body, int legs)
        {
            return true;
        }

        public override void PreUpdateVanitySet(Player player)
        {
            player.GetModPlayer<SymphonyHatPlayer>().isWearingShmphonyHat = true;
        }
    }
}
