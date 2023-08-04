using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace JoJosMod.Armor
{
    [AutoloadEquip(EquipType.Head)]

    internal class LittleRainHood : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 20; Item.height = 20;
            Item.rare = ItemRarityID.Yellow;
            Item.vanity = true;
            Item.value = 2100;
        }
    }
}
