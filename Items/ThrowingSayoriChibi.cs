using JoJosMod.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace JoJosMod.Items
{
    public class ThrowingSayoriChibi : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Strange Poem");
            Tooltip.SetDefault("\"GET OUT OF MY HEAD\"");
        }

        public override void SetDefaults()
        {
            Item.width = 40; Item.height = 40;
            Item.damage = 15;
            Item.DamageType = DamageClass.Ranged;
            Item.rare = ItemRarityID.Pink;
            Item.noUseGraphic = true;
            Item.DefaultToThrownWeapon(ProjectileID.ThrowingKnife, 20, 12, true);
            Item.shoot = ModContent.ProjectileType<SayoriProjectile>();
            Item.noMelee = true;
            Item.consumable = false;
            Item.maxStack = 1;
            Item.stack = 1;
            Item.value = 1000;
        }

        public override void AddRecipes()
        {
            Recipe corruptionRecipe = CreateRecipe();
            corruptionRecipe.AddIngredient(ItemID.Rope, 30);
            corruptionRecipe.AddIngredient(ItemID.FallenStar, 2);
            corruptionRecipe.AddIngredient(ItemID.RottenChunk, 2);
            corruptionRecipe.AddTile(TileID.WorkBenches);
            corruptionRecipe.Register();

            Recipe crimsonRecipe =CreateRecipe();
            crimsonRecipe.AddIngredient(ItemID.Rope, 30);
            crimsonRecipe.AddIngredient(ItemID.FallenStar, 2);
            crimsonRecipe.AddIngredient(ItemID.Vertebrae, 2);
            crimsonRecipe.AddTile(TileID.WorkBenches);
            crimsonRecipe.Register();
        }
    }
}
