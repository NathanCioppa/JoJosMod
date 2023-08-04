using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace JoJosMod.Items
{
    public class SayoriChibi : ModItem
    {

        public override void SetDefaults()
        {
            Item.width = 30; Item.height = 51;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.value = 100;
            Item.rare = ItemRarityID.Pink;
            Item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Rope, 3);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }

        public override Microsoft.Xna.Framework.Vector2? HoldoutOffset()
        {
            return new Microsoft.Xna.Framework.Vector2(-5,-10);
        }



    }
}
