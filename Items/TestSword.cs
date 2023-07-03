using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace JoJosMod.Items
{
	public class TestSword : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bruh");
			Tooltip.SetDefault("DEEZ NUTS!!!!");
		}

		public override void SetDefaults()
		{
			Item.width = 40; Item.height = 40;
			Item.damage = 50;
			Item.DamageType = DamageClass.Melee;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 9.5f;
			Item.value = 10000;
			Item.rare = ItemRarityID.Pink;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.EnchantedBeam;
			Item.shootSpeed = 10;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DirtBlock, 10);
            recipe.AddIngredient(ItemID.Wood, 3);
            recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}