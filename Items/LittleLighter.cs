using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using JoJosMod.Tiles;

namespace JoJosMod.Items
{
    internal class LittleLighter : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Little Lighter");
            Tooltip.SetDefault("Places unlimited lanterns to light up your life\n\"Not all lights can be trusted, but these should be quite safe!\"");
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(10, 2));
        }

        public override void SetDefaults()
        {
            Item.width = 8; Item.height = 12;
            Item.holdStyle = ItemHoldStyleID.HoldFront;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.createTile = TileID.Dirt;
            Item.maxStack = 1;
            Item.createTile = ModContent.TileType<Lantern>();
            Item.placeStyle = 0;         
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.consumable = false;
            Item.rare = ItemRarityID.Yellow;
        }

        public override void HoldItem(Player player)
        {
            Lighting.AddLight(player.itemLocation, TorchID.Torch);
        }

        public override void AddRecipes()
        {
            Recipe leadRecipe = CreateRecipe();
            leadRecipe.AddIngredient(ItemID.Torch, 100);
            leadRecipe.AddIngredient(ItemID.LeadBar, 15);
            leadRecipe.AddIngredient(ItemID.Ruby, 2);
            leadRecipe.Register();

            Recipe ironRecipe = CreateRecipe();
            ironRecipe.AddIngredient(ItemID.Torch, 100);
            ironRecipe.AddIngredient(ItemID.IronBar, 15);
            ironRecipe.AddIngredient(ItemID.Ruby, 2);
            ironRecipe.Register();
        }
    }
}
