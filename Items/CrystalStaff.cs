using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using JoJosMod.Projectiles;

namespace JoJosMod.Items
{
    internal class CrystalStaff : ModItem
    {
        public const int ItemWidthHeight = 56;

        public override void SetStaticDefaults()
        {
            Item.staff[Type] = true;
        }

        public override void SetDefaults()
        {
            Item.height = ItemWidthHeight; Item.width = ItemWidthHeight;
            Item.rare = ItemRarityID.Red;
            Item.value = Item.sellPrice(gold: 10);
            Item.damage = 65;

            Item.DamageType = DamageClass.Magic;
            Item.mana = 4;
            Item.ArmorPenetration = 20;
            Item.autoReuse = true;
            Item.noMelee = true;
            
            Item.useAnimation = 2;
            Item.useTime = 2;
            Item.useStyle = ItemUseStyleID.Shoot;
            
            Item.shoot = ModContent.ProjectileType<CrystalStaffProjectile>();
            Item.shootSpeed = 35;
            
            Item.UseSound = SoundID.Item9;
        }

        public override void AddRecipes()
        {
            Recipe recipie = CreateRecipe();
            recipie.AddIngredient(ItemID.ShadowbeamStaff);
            recipie.AddIngredient(ItemID.CrystalStorm);
            recipie.AddIngredient(ItemID.WaterBolt);
            recipie.AddIngredient(ItemID.Prismite);

            recipie.AddTile(TileID.MythrilAnvil);

            recipie.Register();
        }
    }
}
