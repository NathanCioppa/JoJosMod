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
            Item.rare = ItemRarityID.Pink;
            Item.value = 500;
        }

        public override void SetStaticDefaults()
        {
            ArmorIDs.Head.Sets.DrawHatHair[Item.headSlot] = true;
        }

        public override bool IsVanitySet(int head, int body, int legs)
        {
            return true;
        }

        public override void UpdateVanitySet(Player player)
        {
            player.GetModPlayer<SymphonyHatPlayer>().isWearingShmphonyHat = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.RedString, 1);
            recipe.AddIngredient(ItemID.PinkThread, 5);
            recipe.AddIngredient(ItemID.Silk, 12);
            recipe.AddTile(TileID.Loom);

            recipe.Register();
        }
    }
}
